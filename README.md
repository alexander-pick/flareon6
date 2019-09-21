# flareon6 

![Win!](/done.PNG)

This repo contains files I created during the flareon 6 CTF to serve everybody’s curiosity. I managed to finish the challenge as 206th this year. It was a really amazing ride, pure binary r0ck ‘n’ r011. Here are the files written during the challenges and some notes.
For those who don’t know it, take a look here:
http://flare-on.com/

## 1 - memecat battlestation
Was .NET basics, DNSpy helped to solve this quite quick.

## 2 - overlong
This one was some basic patch training.

## 3 - flarebear
This fancy bear was really a funny challenge. I took a most likely unusable path and brute forced the right combination with a module written for the Xposed Framework. It hooks the process and injects a brute force engine into it which took approximately 3 minutes to trigger the solution on a Samsung A3.

## 4 - dnschess
The first time the chess class in school paid of, I got the idea unexpectedly fast. After setting up the DNS records in a host file I was able to play through after a quick look into the pcap.

## 5 - demo
This one was a bit wicked for me as I never was a gamer or cared on DirectX. All my graphic development I ever did was on Sony hardware and using OGL. Had to read up everything on DirectX and spend a way to much time to look for objects with 0 Alpha. Solved mostly by binary patching and reverse engineering, but a little py script to dump the binary is included.

## 6 - bmphide
My personal arch enemy, I wrote about 1500 lines of code here. In the end the solution of this challenge is the one I admire the most. Seriously after finishing it I felt like Neo in Matrix - "I know Kung Fu" - "Show Me". This advanced process manipulation done here was something I never seen before. Had to learn reflection in C# to solve this. In the end I solved this one by writing a fully reflection based loader wrapping the original binary, it even dynamically generates the reverse functions.

## 7 – wopr
Wargames! I was a fan of this challenge from the first minute. Never did any PyInstaller stuff before, just reversed some pyc for a pentest before. This really showed me what Python is capable of. In the end it required me to solve a linear algebra equation to get this done. I mainly used Z3 for that. Z3 is really an amazing piece of software and it was my first time using it – no regrets I gained this skill here.

## 8 – snake
This one was one of the easier levels for me, since I did a bunch of IoT reversing in the past I am used to work with pure code on sometimes obscure CPUs. To keep track of my work I used an iNES loader for IDA Pro and FCEUX for debugging. This was simply solved by understanding the software and planting the correct number (I think it was 0x26?) in the correct field.

## 9 – reloadered
That was a tough one, got a little bit stuck but in the end it was solved using IDA Pro as debugger and Z3. Amazing what tricks can be played in a binary.

## 10 – mugatu 
A total crazy pill of malware and it was enjoyable to reverse and debug this thing. I cannot forget 1526, one of the most typed offsets during this challenge I think. Really nice and a little weird from a flavor point of perspective and still one of my favourites. Some of the files like the decryptor and my CNC repsonder can be found here.

## 11 – vv_max
Not my favorite but educational. Sadly, I was a bit plagued by some IDA bugs during tracing the functions, but I reported them to Hex-Rays and they are working to fix it. Having IDA 7.3 helped a lot here as it supports the required registers and memory regions. Interesting what can be done using AVX2, I am curious how often you see things like this in “the real world”. Had to use an Azure Machine for this as my computer was labeled “too old”. But hey you made me buy a new HP Laptop now. The solution here was to identify the algorithm used and how to craft the correct answer. After identifying base64_decode this one could be solved.

## 12 – help
Ok – forensics was never my favorite field. I spend quite some time and a lot of energy on this challenge. I am really curious on how the expected solution for this will look like since the path I took in the end looked rather unexpected. There were so many paths to follow, found malware and reversed it etc. but in the end the solution was sitting in memory and was recoverable by floss.
