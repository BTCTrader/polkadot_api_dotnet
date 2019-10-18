# Manual Demos - Milestone 2

Milestone 2 deliverables are tagged as [milestone2](https://github.com/usetech-llc/polkadot_api_dotnet/tree/milestone2)

### Build and run Docker image

```
$ docker build -t polkanet .
$ docker run -it --rm polkanet /bin/bash
```

Now you are connected to a running docker container with API built. You can execute following commands to examine deliverables.

### Build project and run tests

```
# dotnet build
# dotnet test
# dotnet test --filter <test name>
```


## Deliverable 4

### Support following RPC methods

#### state_getKeys
Execute command and watch for the following output:
```
# dotnet test --filter GetKeys

...
2019-10-18 09:13:41.6412|INFO|Polkadot.Logger|FreeBalance hash function is xxHash
...
Storage key for prefix Balances FreeBalance for address 5HQdHxuPgQ1BpJasmm5ZzfSk5RDvYiH6YHfDJVE8jXmp4eig : 0x6D252ECC852DCDCF66504868610B4EE1
...
```

#### state_getStorage (and alias state_getStorageAt)
Execute command and watch for the following output:
```
# dotnet test --filter GetStorage

...
2019-10-18 09:15:51.1020|INFO|Polkadot.Logger|Message body {
  "id": 8,
  "jsonrpc": "2.0",
  "method": "state_getStorage",
  "params": [
    "0x0E4944CFD98D6F4CC374D16F5A4E3F9C",
    "0x4499f4bea.....40a91153375af4c9c6990cc95703cb8fb0f8273099b"
  ]
}
2019-10-18 09:15:51.1020|INFO|Polkadot.Logger|Message 8 was sent
2019-10-18 09:15:51.4098|INFO|Polkadot.Logger|WS Received Message: {"jsonrpc":"2.0","result":"0xb282a95d00000000","id":8}
...
```

#### state_getStorageHash (and alias state_getStorageHashAt)
In the previous test, find the following output:
```
...
2019-10-18 09:15:57.3265|INFO|Polkadot.Logger|Message body {
  "id": 13,
  "jsonrpc": "2.0",
  "method": "state_getStorageHash",
  "params": [
    "0x01EF598903B784A4EB0E8BDCA123C55E",
    "0x4499.....40a91153375af4c9c6990cc95703cb8fb0f8273099b"
  ]
}
2019-10-18 09:15:57.3265|INFO|Polkadot.Logger|Message 13 was sent
2019-10-18 09:15:57.6184|INFO|Polkadot.Logger|WS Received Message: {"jsonrpc":"2.0","result":"0x4fec07430383c2f1bc5ef38805bb16bbd7fa28d2be1aef18ec27c568be8a28b9","id":13}
...
```

#### state_getStorageSize (and alias state_getStorageSizeAt)
In the previous test, find the following output:
```
2019-10-18 09:16:02.8224|INFO|Polkadot.Logger|Message body {
  "id": 17,
  "jsonrpc": "2.0",
  "method": "state_getStorageSize",
  "params": [
    "0x01EF598903B784A4EB0E8BDCA123C55E",
    "0x4499.....40a91153375af4c9c6990cc95703cb8fb0f8273099b"
  ]
}
2019-10-18 09:16:02.8224|INFO|Polkadot.Logger|Message 17 was sent
2019-10-18 09:16:03.1096|INFO|Polkadot.Logger|WS Received Message: {"jsonrpc":"2.0","result":16,"id":17}
...
```

#### state_getChildKeys, state_getChildStorage, state_getChildStorageHash, state_getChildStorageSize
This set of RPC methods is not yet working in Substrate. The test `GetChild` and API methods `GetChildKeys, GetChildStorage, GetChildStorageHash, and GetChildStorageSize` are available, but do not yield any visible results quite yet.

#### state_queryStorage
Execute command and watch for the following output:
```
# dotnet test --filter QueryStorage

...
2019-10-18 09:22:05.5764|INFO|Polkadot.Logger|Message body {
  "id": 6,
  "jsonrpc": "2.0",
  "method": "state_queryStorage",
  "params": [
    [
      "0x0E4944CFD98D6F4CC374D16F5A4E3F9C"
    ],
.....239d349500920d297fbf7ee2aee80b829555947dffd"
  ]
}
2019-10-18 09:22:05.5764|INFO|Polkadot.Logger|Message 6 was sent
2019-10-18 09:22:05.8845|INFO|Polkadot.Logger|WS Received Message: {"jsonrpc":"2.0","result":[{"block":"0xf564301df7c022e374bc5039034e08926a77dc2a7e670be0a725ae00b16e2d6e","changes":[["0x0e4944cfd.....c374d16f5a4e3f9c","0x1a84a95d00000000"]]}],"id":6}
...
```


## Deliverable 5

### Address balance (RPC method state_subscribeStorage with appropriate storage address filter)
Execute command and watch for the following output:
```
# dotnet test --filter Wssubscribe

...
2019-10-18 09:28:18.3446|INFO|Polkadot.Logger|Message body {
  "id": 3,
  "jsonrpc": "2.0",
  "method": "state_subscribeStorage",
  "params": [
    [
      "0x6D252ECC852DCDCF66504868610B4EE1"
    ]
  ]
}
2019-10-18 09:28:18.3446|INFO|Polkadot.Logger|Message 3 was sent
2019-10-18 09:28:18.6374|INFO|Polkadot.Logger|WS Received Message: {"jsonrpc":"2.0","result":45412,"id":3}
2019-10-18 09:28:18.6374|INFO|Polkadot.Logger|Message received: {"jsonrpc":"2.0","result":45412,"id":3}
2019-10-18 09:28:18.6422|INFO|Polkadot.Logger|WS Received Message: {"jsonrpc":"2.0","method":"state_storage","params":{"result":{"block":"0xafbb5bc4db0dd3b54699a942644c54be39202fe363cfbd8fbc3b6fa3.....0d300000000000000000000"]]},"subscription":45412}}
2019-10-18 09:28:18.6422|INFO|Polkadot.Logger|Message received: {"jsonrpc":"2.0","method":"state_storage","params":{"result":{"block":"0xafbb5bc4db0dd3b54699a942644c54be39202fe363cfbd8fbc3b6fa3a18.....0d300000000000000000000"]]},"subscription":45412}}
2019-10-18 09:28:18.6422|INFO|Polkadot.Logger|Subscribed with subscription ID: 45412

Balance: 667670699885504116799286805151088640

...
2019-10-18 10:18:53.2585|INFO|Polkadot.Logger|Message body {
  "id": 4,
  "jsonrpc": "2.0",
  "method": "state_unsubscribeStorage",
  "params": [
    29757
  ]
}
2019-10-18 10:18:53.2585|INFO|Polkadot.Logger|Message 4 was sent
2019-10-18 10:18:53.5560|INFO|Polkadot.Logger|WS Received Message: {"jsonrpc":"2.0","result":true,"id":4}
2019-10-18 10:18:53.5560|INFO|Polkadot.Logger|Message received: {"jsonrpc":"2.0","result":true,"id":4}
2019-10-18 10:18:53.5560|INFO|Polkadot.Logger|Unsubscribed from subscription ID: 29757
...
```

### Current era and epoch info (RPC method state_subscribeStorage with appropriate storage filters)
This test will run twice. One time for Alexander network and one time for Kusama to test both Era/Session and Era/Epoch models.
Execute command and watch for the following output:
```
# dotnet test --filter WssubscribeEraSession

...
--- Alexander ---
...
2019-10-18 09:43:16.2594|INFO|Polkadot.Logger|Message body {
  "id": 4,
  "jsonrpc": "2.0",
  "method": "state_subscribeStorage",
  "params": [
    [
      "0xe781aa1e06ea53e01a4e129e0496764e",
  .....  "0xB8F48A8C01F629D6DC877F64892BED49"
    ]
  ]
}
...

Session: 15  / 50
Era: 465 /  600

...



--- Kusama ---
...
2019-10-18 09:43:26.8747|INFO|Polkadot.Logger|Message body {
  "id": 10,
  "jsonrpc": "2.0",
  "method": "state_subscribeStorage",
  "params": [
    [
      "0x513A0658F849101C35B0BA116A2BBE4A",
 .....  "0x137A2A48EEB4491643F107BCB12F1F81"
    ]
  ]
}
...

Epoch: 2395  /  2400
Era: 14395 /  14400

...
```


## Deliverable 6

### One transaction type is supported with dedicated API call - sending DOTs to another address
This is manual test because testDOTs will be consumed and a private key is required. Change directory to /src/SignAndSendTransferTest project and execute the following. If you need assistance with a working private key and addresses, please let me (Greg) know, I will provide you the key pair.

- Transaction is serialized and prepared (formatted) appropriately for signing
- Transaction can be signed with provided private key
- Cryptogram can be sent to the substrate node to be processed and included in the blockchain
- Command line tool is provided to execute all milestone deliverables

```
# cd /src/SignAndSendTransferTest
# dotnet build
# dotnet run <sender address> <recipient address> <amount in fDOTs> <sender private key (hex)>
```

Expect output such as:
```
...
2019-10-18 12:47:26.1334|INFO|Polkadot.Logger|Message body {
  "id": 5,
  "jsonrpc": "2.0",
  "method": "author_submitAndWatchExtrinsic",
  "params": [
    "0x250281FF5E8135DC17F025CA044780631EF89.....D79DF6ACA044DF12BA9B727110FEBF95BFF2D0C0104"
  ]
}
...

2019-10-18 12:47:26.4346|INFO|Polkadot.Logger|Message received: {"jsonrpc":"2.0","method":"author_extrinsicUpdate","params":{"result":"ready","subscription":45421}}
{
  "result": "ready",
  "subscription": 45421
}
...
```

Also, feel free to check the address on [Polkascan](https://polkascan.io).


### Support following RPC methods
#### author_submitExtrinsic
Change directory to /src/SubmitExtrinsicTest project and execute the following.
```
# cd /src/SubmitExtrinsicTest
# dotnet build
# dotnet run <sender address> <recipient address> <amount in fDOTs> <sender private key (hex)>




TBD

```

#### author_pendingExtrinsics


```
# cd /src/PolkaTest
# dotnet test --filter PendingExtrinsic

...
2019-10-18 13:24:07.2158|INFO|Polkadot.Logger|Message body {
  "id": 3,
  "jsonrpc": "2.0",
  "method": "author_pendingExtrinsics",
  "params": []
}
2019-10-18 13:24:07.2158|INFO|Polkadot.Logger|Message 3 was sent
2019-10-18 13:24:07.5535|INFO|Polkadot.Logger|WS Received Message: {"jsonrpc":"2.0","result":["0x8d0281ff66adb5ec78edf4c64dac3970609c8c0c7cc1d69c0bec3f37f4b4677b2feb3b05a26b243bc322192ff5f56f9c679.....09a955c1ca5ecb6a822ff5d210420e2c15000506"],"id":3}
...
SignerAddress: ykriwdQ4WKNedoD6R...NwWknTqRY1F
Signature: Polkadot.Api.Signature
Method: Polkadot.Api.GenericMethod
Length: 163
...
```

#### author_removeExtrinsic
```
TBD
```


## Deliverable 7

### API and example full documentation

### Cleanup project files, ensure all tests pass
The following commits include pre-release code cleanup:
```
a312542 - WIP - Milestone 2
41dca9c - fix UnsubscribeStorage
e5b780d - Added debug output for acceptance testing
6833dd8 - Fixed compiler warnings

```


### API library is packaged as a zip archive with DLL files that can be used without compilation on Windows.

## Extra Deliverables

### Kusama Metadata support
Execute command and watch for the following output, especially "Unsing epochs" string that indicates that Kusama epochs are detected:
```
# dotnet test --filter GetMetadataV7

...
2019-10-18 10:48:30.6602|INFO|Polkadot.Logger|Connected to wss://kusama-rpc.polkadot.io/
...
2019-10-18 10:48:31.0296|INFO|Polkadot.Logger|Message body {
  "id": 2,
  "jsonrpc": "2.0",
  "method": "state_getMetadata",
  "params": []
}
...
2019-10-18 10:48:38.8470|INFO|Polkadot.Logger|FreeBalance hash function is xxHash
2019-10-18 10:48:38.8470|INFO|Polkadot.Logger|Balances module index: 4
2019-10-18 10:48:38.8470|INFO|Polkadot.Logger|Transfer call index: 0
2019-10-18 10:48:38.8519|INFO|Polkadot.Logger|Using epochs
...
```
