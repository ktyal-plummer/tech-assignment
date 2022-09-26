# Email Validator
A .NET console application that searches a directory for a user specified .csv file. It will then parse that file for email adresses and output the valid and invalid addresses found.

## Setup
Requires .NET 6.0

To start:

    git clone https://github.com/ktyal-plummer/tech-assignment.git

## Usage 
Typing `quit` or `q` during any prompt will exit the program

Typing `set` or `s` will prompt you to set a directroy

Starting the program:

    dotnet run

To use the testing directory input:
    
    Please enter a valid directory to search: ./testdir
    
To prase a file within the test directory:

    Please enter a valid file name: valid
    
or 

    Please enter a valid file name: valid.csv

