
# TOC

- [Functional Requirements](#functional-requirements)
    - [Passwords](#passwords)
    - [Credential Sets](#credential-sets)
    - [User Interfaces](#user-interfaces)
        - [Login](#login)
        - [Credential Sets Handling](#credential-sets)
        - [Master Password Handling](#master-password-handling) 
        - [Synchronization Handling](#synchronization-handling)
    - [Vault Storing](#vault-storing)
    - [Miscellaneous](#miscellaneous)
- [Non-Functional Requirements](#non-functional-requirements)
    - [Encryption Algorithms Requirements](#encryption-algorithms-requirements)
    - [Master Password and Credential Sets Security](#master-password-and-credential-sets-security)
    - [User Interfaces Security](#user-interfaces-security)
        - [Login Security](#login-security)
        - [Credential Sets Handling Security](#credential-sets-handling-security)
        - [Synchronization Security](#synchronization-security)
    - [Vault Security](#vault-security)
    - [Other Security Features](#other-security-features)

# Functional Requirements

## Passwords

Each credential set password and the master password must: 
1. at least be 10 characters long 
2. at least contain:
    1. a capital letter
    2. a lowercase letter
    3. a number 
    4. a special character between:
        - ``-``
        - ``+``
        - ``_``
        - ``&``
        - ``%``
        - ``@`` 
        - ``$``
        - ``?``
        - ``!``
        - ``#``
3. expire after 3 month by default
    1. warning must be shown upon each login if the password is expired 
    2. user must be able to ignore the warning
    3. user must be able to flag any password but the master one as never expiring

## Credential Sets

Each credential set must have:
1. a unique id
2. a password that must be compliant to each requirement in [Passwords](#passwords) section. The password must be typed by the user or automatically generated
3. _optional_ fields:
    1. username 
    2. e-mail
    3. free text for any kind of note
    4. user defined labels

## User Interfaces

### Login

Login interface must allow the user to:
1. initialize a new vault, if and only the vault does not exist yet  
2. import a vault from another device, if and only the vault does not exist yet
    1. both previuos and newly imported vault master passwords must be provided and checked
3. type in the master password to login, if and only the vault exists 
    1. typed password must be checked
4. delete the existing vault
    1. master password must be provided and checked

### Credential Sets Handling

Credential sets handling interface must allow the user to:
1. add a new credential set 
    1. master password must be provided and checked
2. copy a credential set password to clipboard
3. edit any field of each credential set and save those changes
    1. master password must be provided and checked 
4. delete a credential set
    1. master password must be provided and checked 
5. notice credential sets whose passwords are expired by showing ad hoc warning 
6. notice credential sets whose passwords are flagged abs never expiring by showing ad hoc warning 
7. see all credential sets inside the vault. Only the following fields must be always shown:
    - id 
    - e-mail (this field must be empty if the e-mail does not exist)
    - username (this field must be empty if the username does not exist)  
    - expiration date/warning 
Plain text password and free text fields must be shown shown on user demand
8. look for one or more credential sets typing a string that may be in id, username and/or e-mail fields
9. group credential sets by a specific label
10. order credential sets by id, username, e-mail or expiration date


### Master Password Handling

Master password handling interface must:
1. show the expiration date of the master password
2. allow the user to change the master password 
    1. old master password must be provided and checked
    2. new master password must be typed two times. New master password must be approved if and only both strings are equal to each other
    3. vault must be encrypted with the newer master password
3. warn the user with ad hoc icon and a message if the master password is expired

### Synchronization Handling

Synchronization handling interface must allow the user to:
1. send its own vault to another device
    1. master password must be provided and checked
2. receive a vault from another device
    1. this operation must overwrite the existing vault 
    

## Vault Storing

1. Vault data must be stored in a file
2. Vault file must be updated every time a change in vault data is made 
3. Vault file must be read at each startup to load its content 
4. User must be able to export a copy of the vault to a desired position in the file system
 
## Miscellaneous 

1. the user must be able to logout



# Non-Functional Requirements

## Encryption Algorithms Requirements

1. PDKDF2 must be used as key derivation and hash function 
    1. salt value must be unique
    2. HMAC-SHA512 must be used as hash algorithm ([OWASP advice](https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html#pbkdf2))
2. symmetric encryption must be performed using AES GCM algorithm
    1. encryption key must be the output of the key derivation algorithm applied to the chosen password and a newly generated salt
    2. inizialization vector must be unique
3. asymmetric encryption must be preformed using RSA algorithm

Each time that one of those algorithms is cited in the text below, its requirements must be enforced.


## Master password Security

1. master password must be stored as its corresponding hash
    1. hash must be computed using PBKDF2 
2. master password must be different from previous ones, if changed 
    1. old master password must be encrypted with the current one

## User Interfaces Security 

### Login Security

1. incremental delay time must take place for each time a wrong master password is typed to login. Mandatory delays:
    - first three errors: no delay time
    - fourth error: 5 seconds 
    - from fifth error onward: previos attempt delay time multiplied by four

### Credential Sets Handling Security  

1. clipboard must be overwritten with random data or physically erased after 20 seconds, when copying a password

### Synchronization Security

1. peer to peer communication during vault synching operations must:
    1. be encrypted using RSA algorithm to exchange an OTP
    2. use the OTP to cypher the vault using AES before sending 
2. a timestamp must be included as AAD inside the AES
    1. any vault sent 1 minute before or earlier must be ignored 
3. sender must generate a random OTP (here called _vault tag_ for simplicity) for each communication
    1. vault tag must be a 6-character alphanumeric string
    2. vault tag must be part of AES AAD 


## Vault Security 

1. vault file must be encrypted using the master password as AES key
    1. the following data must be stored in plain text:
        1. master password hash and salt
        2. KDF function salt, AES initialization vector and AES tag used to compute vault encryption
    3. already used salts vaules, initialization vectors, old synchronization AES OTP, old vault tags and old master passwords must be stored inside the vault 
2. vault integrity must be checked before importing its content inside the application 
    1. content loading operation must be stopped, if vault integrity has been compromised
    2. user must be warn, if vault integrity has been compromised
3. user must be able to export the vault:
    1. encrypted with its master password
    2. encrypted with a different master password. New master password must be provided or automatically generated, depending on user choice
    3. as a plain text file. This option must be discouraged and used if and only the user is ok with handling data encryption on his own   
    4. master password must be provided and checked in all previous cases 

## Other Security Features

1. logout must take place after 2 minutes with no interaction with the application 
