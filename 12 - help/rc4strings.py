def KSA(key):
    keylength = len(key)

    S = range(256)

    j = 0
    for i in range(256):
        j = (j + S[i] + key[i % keylength]) % 256
        S[i], S[j] = S[j], S[i]  # swap

    return S


def PRGA(S):
    i = 0
    j = 0
    while True:
        i = (i + 1) % 256
        j = (j + S[i]) % 256
        S[i], S[j] = S[j], S[i]  # swap

        K = S[(S[i] + S[j]) % 256]
        yield K


def RC4(key):
    S = KSA(key)
    return PRGA(S)


def convert_key(s):
    return [ord(c) for c in s]


def convert_ct(s):
    import binascii
    return [ord(ch) for ch in binascii.unhexlify(s)]


if __name__ == '__main__':
    key = 'f1176d6e'
    ciphertext = '016497c8f6d0fbf4'

    key = convert_ct(key)

    keystream = RC4(key)

    ciphertext = convert_ct(ciphertext)

    plaintext = ''.join([chr(c ^ keystream.next()) for c in ciphertext])
    print(plaintext)
