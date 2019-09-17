// bf file decryptor for flareon6 - challenge 9 "mugatu"
// based on https://github.com/jpiechowka/xtea-file-encryptor/blob/master/src/XTEA.cpp

#include <iostream>
#include <fstream>
#include <stdint.h>
#include <cstring>

using namespace std;

#define BLOCK_SIZE 8 //XTEA uses 64-bit blocks, 64 bits is 8 bytes

unsigned char key[4] = { 0x31, 0, 0, 0 };

bool found = false;

//XTEA block cipher - code from Wikipedia
//https://en.wikipedia.org/wiki/XTEA

void decipher(unsigned int num_rounds, uint32_t v[2], uint8_t const key[4])
{
	unsigned int i;
	uint32_t v0 = v[0], v1 = v[1], delta = 0x9E3779B9, sum = delta * num_rounds;
	for (i = 0; i < num_rounds; i++)
	{
		v1 -= (((v0 << 4) ^ (v0 >> 5)) + v0) ^ (sum + key[(sum >> 11) & 3]);
		sum -= delta;
		v0 -= (((v1 << 4) ^ (v1 >> 5)) + v1) ^ (sum + key[sum & 3]);
	}
	v[0] = v0; v[1] = v1;
}

void xtea(char filePath[])
{
	//Open file
	fstream file(filePath, ios::in | ios::out | ios::binary);
	if (!file) //Check if file is correctly opened
	{
		cout << "File " << filePath << " cannot be opened" << endl; 
		return;
	}
	
	

	file.seekg(0, ios::end);
	unsigned fileSize = file.tellg(); //Get file size
	file.seekg(ios::beg);
	file.clear();

	//Calculate number of blocks to be encrypted/decrypted
	int blockNumber = fileSize / BLOCK_SIZE;
	if (fileSize % BLOCK_SIZE != 0) { ++blockNumber; }

	//Decalre data array for file operations
	unsigned char dataArray[BLOCK_SIZE];
	unsigned filePosition = file.tellg();
	
	bool firstround = true;
	
	for (int i = 0; i < blockNumber; i++)
	{
		//Get data from file
		file.seekg(filePosition);
		file.read((char*)dataArray, BLOCK_SIZE);
		
		//decrypt
		decipher(32, (uint32_t*)dataArray, key); 
		
		// check and abort 
		// 0x47, 0x49, 0x46
		
		if(firstround) {
			
			cout << key[0] << key[1] << key[2] << key[3] << endl;
			
			//cout << dataArray[0] << dataArray[1] << dataArray[2] << endl;
			
			//look for GIF header
			if(dataArray[0] == 0x47) {
				if(dataArray[1] == 0x49) {
					if(dataArray[2] == 0x46) {
						if(dataArray[3] == 0x38) {
							firstround = false;
							found = true;
							cout << "Found Magic" << endl;
						} else {
							file.close();
							return;
						}
					} else {
						file.close();
						return;
					}
				} else {
					file.close();
					return;
				}
			} else {
				file.close();
				return;
			}
		}
		
		//cout << "decrypting offset: " << filePosition << endl;

		//Write to file
		file.seekp(filePosition);
		file.write((char*)dataArray, BLOCK_SIZE);

		//Zero out the data array and increase the pos counter
		memset(dataArray, 0, BLOCK_SIZE);
		filePosition += BLOCK_SIZE;
	}
	//Close file
	file.close();

}

int main(int argc, char *argv[])
{
	if (argc != 2) 
	{
		cout << "invalid params" << endl;
		return 1;
	}
	
	//decrypt try all printables
	for (int i = 0x20; i <= 0xff; i++) {
		key[1] = i;
		for (int j = 0x20; j <= 0xff; j++) {
			key[2] = j;
			for (int p = 0x20; p <= 0xff; p++) {
				key[3] = p;
				xtea(argv[1]);
				if(found) {
					return 0;
				}
			}
		}
	}
	
	return 0;
}

