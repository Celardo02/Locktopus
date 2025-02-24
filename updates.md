
# Future Updates

## Login

- user may be able to set a recovery password, during vault initialization. Recovery password must be used if and only the master password is lost. Recovery password must be _optional_
    - master password must be stored inside the vault if and only a recovery password is defined
        - encryption must be performed using AES GCM. The recovery password must be used as encryption key
- adding mfa
    - incremental delays must take place to avoid bruteforce attacks

## Credential Storage

- user may be able to spcify custom password expiration time
- user may be able to choose whether master password must be provided or not before getting a password from the vault. 
    - Same behavior may take place before showing _free text_ or _password_ fields in plain text

## Miscellaneous

- application may support multiple languages
