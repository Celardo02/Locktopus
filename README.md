
# Locktopus

_Locktopus_ is a cross platform password manager under development. It will run on:
- Linux;
- Windows; 
- Android. 

Any other platform will not be supported.

## TOC

- [Key Features](#key-features)
- [Future Updates](#future-updates)
    - [Login](#login)
    - [Credential sets Storage](#credential-sets-storage)
    - [Miscellaneous](#miscellaneous)

## Key Features 

Locktopus aims to be a very simple password manager that does not save any data on a remote server to maximize privacy. All information will be encrypted and stored locally on the device.  
However, it will always be possible to back up the encrypted password vault to the user's preferred backup system.  

Since no remote server is involved, synchronization between multiple devices is handled through peer-to-peer communication, which must be explicitly triggered by the user.

## Future Updates

### Login

- user may be able to set a recovery password, during vault initialization. Recovery password must be used if and only the master password is lost. Recovery password must be _optional_
    - master password must be stored inside the vault if and only a recovery password is defined
        - encryption must be performed using AES GCM. The recovery password must be used as encryption key
- adding mfa
    - incremental delays must take place to avoid bruteforce attacks

### Credential Sets Storage

- user may be able to spcify custom password expiration time
- user may be able to choose whether master password must be provided or not before getting a password from the vault. 
    - Same behavior may take place before showing _free text_ or _password_ fields in plain text

### Miscellaneous

- application may support multiple languages