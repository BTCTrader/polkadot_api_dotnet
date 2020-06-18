﻿namespace Polkadot.Api
{
    using System;
    using System.Numerics;
    using Polkadot.Data;
    using Polkadot.DataStructs;
    using Polkadot.DataStructs.Metadata;
    using Polkadot.src.DataStructs;

    public interface IApplication : IDisposable
    {
        int Connect(string node_url = "", string metadataBlockHash = null);

        void Disconnect();

        /// <summary>
        /// Retreives the current nonce for specific address
        /// </summary>
        /// <param name="address"> the address to get nonce for </param>
        /// <returns> address nonce </returns>
        BigInteger GetAccountNonce(Address address);

        /// <summary>
        /// Call 4 methods and put them together in a single object
        /// system_chain
        /// system_name
        /// system_version
        /// system_properties
        /// </summary>
        SystemInfo GetSystemInfo();

        /// <summary>
        ///  Retreives the block hash for specific block
        /// </summary>
        /// <param name=""> struct with blockNumber block number </param>
        /// <returns> BlockHash struct with result </returns>
        BlockHash GetBlockHash(GetBlockHashParams param);

        /// <summary>
        ///  Retreives the runtime version information for specific block
        /// </summary>
        /// <param name=""> struct with blockHash 64 diget number in hex format </param>
        /// <returns> RuntimeVersion struct with result </returns>            
        RuntimeVersion GetRuntimeVersion(GetRuntimeVersionParams param);

        /// <summary>
        ///  Get header and body of a relay chain block
        /// </summary>
        /// <param name=""> struct with blockHash 64 diget number in hex format </param>
        /// <returns> SignedBlock struct with result </returns>     
        SignedBlock GetBlock(GetBlockParams param);

        /// <summary>
        /// Retrieves the header for a specific block
        /// </summary>
        /// <param name="param"> struct with blockHash 64 diget number in hex format </param>
        /// <returns> BlockHeader struct with result </returns>
        BlockHeader GetBlockHeader(GetBlockParams param);

        /// <summary>
        /// Returns current state of the network
        /// </summary>
        /// <returns>
        /// NetworkState struct with result
        /// </returns>
        NetworkState GetNetworkState();

        /// <summary>
        /// Get hash of the last finalized block in the chain
        /// </summary>
        /// <returns> FinalHead struct with result </returns>
        FinalHead GetFinalizedHead();

        /// <summary>
        ///  Retreives the runtime metadata for specific block
        /// </summary>
        /// <param name="param"> (optional) struct with blockHash 64 diget number in hex format </param>
        /// <param name="force"> (default false) use cache </param>
        /// <returns> Metadata struct with result </returns>
        MetadataBase GetMetadata(GetMetadataParams param, bool force = false);

        /// <summary>
        ///  Generates storage key for a certain Module and State variable defined by parameter and prefix. Parameter is a JSON
        ///   string representing a value of certain type, which has two fields: type and value.Type should be one of type
        ///   strings defined above.Value should correspond to the type.Example:
        ///
        ///      { "type" : "AccountId", "value" : "5ECcjykmdAQK71qHBCkEWpWkoMJY6NXvpdKy8UeMx16q5gFr"}
        ///
        ///   Information about Modules and State variables(with parameters and their types) is returned by getMetadata
        ///   method.
        /// </summary>
        /// <param name="jsonPrm"> JSON string that contains parameter and its type</param>
        /// <param name="module"> module (as in metadata)</param>
        /// <param name="variable"> state variable (as in metadata for given module)</param>
        /// <returns> Storage key </returns>
        string GetKeys<T>(T prm, string module, string variable) where T : ITypeCreate;

        string GetKeys(string module, string variable);

        /// <summary>
        ///  Reads storage for a certain Module and State variable defined by parameter and prefix.Parameter is a JSON
        ///   string representing a value of certain type, which has two fields: type and value.Type should be one of type
        ///   strings defined above.Value should correspond to the type.Example:
        ///
        ///      { "type" : "AccountId", "value" : "5ECcjykmdAQK71qHBCkEWpWkoMJY6NXvpdKy8UeMx16q5gFr"}
        ///
        ///   Information about Modules and State variables(with parameters and their types) is returned by getMetadata
        ///   method.
        /// </summary>
        /// <param name="jsonPrm"> JSON string that contains parameter and its type</param>
        /// <param name="module"> module (as in metadata)</param>
        /// <param name="variable"> state variable (as in metadata for given module)</param>
        /// <returns> Storage content </returns>
        string GetStorage(string module, string variable);

        string GetStorage<T>(T prm, string module, string variable) where T : ITypeCreate;

        /// <summary>
        /// Returns storage hash of given State Variable for a given Module defined by parameter.
        ///  Parameter is a JSON string representing a value of certain type, which has two fields: type and value.Type
        ///  should be one of type strings defined above.Value should correspond to the type. Example:
        ///
        ///      { "type" : "AccountId", "value" : "5ECcjykmdAQK71qHBCkEWpWkoMJY6NXvpdKy8UeMx16q5gFr"}
        ///
        ///   Information about Modules and State variables(with parameters and their types) is returned by getMetadata
        ///   method.
        /// </summary>
        /// <param name="jsonPrm"> JSON string that contains parameter and its type</param>
        /// <param name="module"> module (as in metadata)</param>
        /// <param name="variable"> state variable (as in metadata for given module)</param>
        /// <returns> Storage hash </returns>
        string GetStorageHash<T>(T prm, string module, string variable) where T : ITypeCreate;

        string GetStorageHash(string module, string variable);

        /// <summary>
        /// Returns storage size for a given State Variable for a given Module defined by parameter.
        ///  Parameter is a JSON string representing a value of certain type, which has two fields: type and value.Type
        ///  should be one of type strings defined above.Value should correspond to the type. Example:
        ///
        ///      { "type" : "AccountId", "value" : "5ECcjykmdAQK71qHBCkEWpWkoMJY6NXvpdKy8UeMx16q5gFr"}
        ///
        ///   Information about Modules and State variables(with parameters and their types) is returned by getMetadata
        ///   method.
        /// </summary>
        /// <param name="jsonPrm"> JSON string that contains parameter and its type</param>
        /// <param name="module"> module (as in metadata)</param>
        /// <param name="variable"> state variable (as in metadata for given module)</param>
        /// <returns> Storage size </returns>
        int GetStorageSize<T>(T prm, string module, string variable) where T : ITypeCreate;

        int GetStorageSize(string module, string variable);

        /// <summary>
        /// Calls storage_getChildKeys RPC method with given child storage key and storage key
        /// </summary>
        /// <param name="childStorageKey">string with 0x prefixed child storage key hex value</param>
        /// <param name="storageKey">string with 0x prefixed storage key hex value</param>
        /// <returns>string response from RPC method</returns>
        string GetChildKeys(string childStorageKey, string storageKey);

        /// <summary>
        /// Calls storage_getChildStorage RPC method with given child storage key and storage key
        /// </summary>
        /// <param name="childStorageKey"> string with 0x prefixed child storage key hex value </param>
        /// <param name="storageKey"> string with 0x prefixed storage key hex value </param>
        /// <returns> string response from RPC method </returns>
        string GetChildStorage(string childStorageKey, string storageKey);

        /// <summary>
        /// Calls storage_getChildStorageHash RPC method with given child storage key and storage key
        /// </summary>
        /// <param name="childStorageKey"> string with 0x prefixed child storage key hex value </param>
        /// <param name="storageKey"> string with 0x prefixed storage key hex value </param>
        /// <returns> string response from RPC method </returns>
        string GetChildStorageHash(string childStorageKey, string storageKey);

        /// <summary>
        /// Calls storage_getChildStorageSize RPC method with given child storage key and storage key
        /// </summary>
        /// <param name="childStorageKey">  string with 0x prefixed child storage key hex value </param>
        /// <param name="storageKey"> string with 0x prefixed storage key hex value </param>
        /// <returns> int response from RPC method </returns>
        int GetChildStorageSize(string childStorageKey, string storageKey);

        /// <summary>
        /// Returns the currently connected peers
        /// </summary>
        /// <returns>
        /// PeersInfo struct with result
        /// </returns>
        PeersInfo GetSystemPeers();

        /// <summary>
        /// Return health status of the node
        /// </summary>
        /// <returns>
        /// SystemHealth struct with result
        /// </returns>
        SystemHealth GetSystemHealth();

        /// <summary>
        /// Sign a transfer with provided private key, submit it to blockchain, and wait for completion. Once transaction is
        /// accepted, the callback will be called with parameter "ready". Once completed, the callback will be called with
        /// completion result string equal to "finalized".
        /// </summary>
        /// <param name="sender"> address of sender (who signs the transaction) </param>
        /// <param name="privateKey"> 64 byte private key of signer in hex, 2 symbols per byte (e.g. "0102ABCD...") </param>
        /// <param name="recipient"> address that will receive the transfer </param>
        /// <param name="amount"> amount (in femto DOTs) to transfer </param>
        /// <param name="callback"> delegate that will receive operation updates </param>
        string SignAndSendTransfer(string sender, string privateKey, string recipient, BigInteger amount, Action<string> callback);

        /// <summary>
        /// Subscribe to era and session. Only one subscription at a time is allowed. If a subscription already
        ///  exists, old subscription will be discarded and replaced with the new one.Until subscribeEraAndSession method is
        ///  called, the API will be receiving updates and forwarding them to subscribed object/function.Only
        ///  unsubscribeBlockNumber will physically unsubscribe from WebSocket endpoint updates.
        /// </summary>
        /// <param name="callback"> expression that will receive updates </param>
        /// <returns> operation result </returns>
        string SubscribeEraAndSession(Action<Era, SessionOrEpoch> callback);

        /// <summary>
        /// Subscribe to most recent value updates for a given storage key. Only one subscription at a time per address is
        ///     allowed. If a subscription already exists for the same storage key, old subscription will be discarded and
        ///     replaced with the new one. Until unsubscribeStorage method is called with the same storage key, the API will be
        ///     receiving updates and forwarding them to subscribed object/function. Only unsubscribeStorage will physically
        ///     unsubscribe from WebSocket endpoint updates.
        /// </summary>
        /// <param name="key"> storage key to receive updates for (e.g. "0x66F795B8D457430EDDA717C3CBA459B9") </param>
        /// <param name="callback"> expression that will received </param>
        /// <returns> Subscription id </returns>
        string SubscribeStorage(string key, Action<string> callback);

        /// <summary>
        /// Subscribe to most recent balance for a given address. Only one subscription at a time per address is allowed. If
        ///     a subscription already exists for the same address, old subscription will be discarded and replaced with the new
        ///     one. Until unsubscribeBalance method is called with the same address, the API will be receiving updates and
        ///     forwarding them to subscribed object/function.Only unsubscribeBalance will physically unsubscribe from WebSocket
        ///     endpoint updates.
        /// </summary>
        /// <param name="address"> address to receive balance updates for </param>
        /// <param name="callback">  expression that will receive balance updates </param>
        /// <returns> Subscription id </returns>
        string SubscribeBalance(string address, Action<BigInteger> callback);

        /// <summary>
        /// Returns all pending extrinsics
        /// </summary>
        /// <param name="bufferSize"> size of preallocated array </param>
        /// <returns> 
        ///     Extrinsics received from the node (may be greater than buffer size, in which case items with
        ///     indexes greater than bufferSize are not returned) 
        /// </returns>
        GenericExtrinsic[] PendingExtrinsics(int bufferSize);

        /// <summary>
        /// Subscribe to nonce updates for a given address. Only one subscription at a time per address is allowed. If
        /// a subscription already exists for the same address, old subscription will be discarded and replaced with the new
        /// one.Until unsubscribeNonce method is called with the same address, the API will be receiving updates and
        /// forwarding them to subscribed object/function.Only unsubscribeNonce will physically unsubscribe from WebSocket
        /// endpoint updates.
        /// </summary>
        /// <param name="address"> address to receive nonce updates for </param>
        /// <param name="callback"> delegate expression that will receive nonce updates </param>
        /// <returns> operation result </returns>
        string SubscribeAccountNonce(Address address, Action<BigInteger> callback);

        /// <summary>
        /// Submit a fully formatted extrinsic for block inclusion
        /// </summary>
        /// <param name="encodedMethodBytes"> encoded extrintic parametrs </param>
        /// <param name="module"> invoked module name </param>
        /// <param name="method"> invoked method name </param>
        /// <param name="sender"> sender address </param>
        /// <param name="privateKey"> sender private key </param>
        /// <returns> Extrinsic hash </returns>
        string SubmitExtrinsic(byte[] encodedMethodBytes, string module, string method, Address sender, string privateKey);

        /// <summary>
        /// Remove given extrinsic from the pool and temporarily ban it to prevent reimporting
        /// </summary>
        /// <param name="extrinsicHash"> hash of extrinsic as returned by submitExtrisic </param>
        /// <returns> Operation result </returns>
        bool RemoveExtrinsic(string extrinsicHash);

        /// <summary>
        /// Calls state_queryStorage RPC method to get historical information about storage at a key
        /// </summary>
        /// <param name="key"> storage key to query </param>
        /// <param name="startHash"> hash of block to start with </param>
        /// <param name="stopHash"> hash of block to stop at </param>
        /// <param name="itemCount"> size of StorageItem elements for retrieve </param>
        /// <returns> array of StorageItem elements </returns>
        StorageItem[] QueryStorage(string key, string startHash, string stopHash, int itemCount);

        /// <summary>
        /// Subscribe to most recent block number.Only one subscription at a time is allowed.If a subscription already 
        /// exists, old subscription will be discarded and replaced with the new one.Until unsubscribeBlockNumber method is
        /// called, the API will be receiving updates and forwarding them to subscribed object/function.Only
        /// unsubscribeBlockNumber will physically unsubscribe from WebSocket endpoint updates.
        /// </summary>
        /// <param name="callback"> callback - delegate that will receive updates</param>
        /// <returns> operation result </returns>
        string SubscribeBlockNumber(Action<long> callback);

        /// <summary>
        /// Unsubscribe from WebSocket endpoint and stop receiving updates with most recent block number.
        /// </summary>
        /// <param name="id"> Subscription id </param>
        /// <returns> operation result </returns>
        void UnsubscribeBlockNumber(string id);

        /// <summary>
        /// Subscribe to most recent runtime version.This subscription is necessary for applications that keep connection
        /// for a long time.If update about runtime version arrives, it will be necessary to disconnect and reconnect since
        /// module and method indexes might have changed.
        /// 
        /// Only one subscription at a time is allowed.If a subscription already
        /// exists, old subscription will be discarded and replaced with the new one.Until unsubscribeRuntimeVersion method
        /// is called, the API will be receiving updates and forwarding them to subscribed object/function.Only
        /// unsubscribeRuntimeVersion will physically unsubscribe from WebSocket endpoint updates.
        /// </summary>
        /// <param name="callback"> callback - delegate that will receive updates </param>
        /// <returns> operation result </returns>
        string SubscribeRuntimeVersion(Action<RuntimeVersion> callback);

        /// <summary>
        /// Submit and subscribe a fully formatted extrinsic for block inclusion
        /// </summary>
        /// <param name="encodedMethodBytes"> encoded extrintic parametrs </param>
        /// <param name="module"> invokable module name </param>
        /// <param name="method"> invokable method name</param>
        /// <param name="sender"> sender address </param>
        /// <param name="privateKey">  sender private key </param>
        /// <param name="callback"> expression that will receive operation updates </param>
        /// <returns></returns>
        string SubmitAndSubcribeExtrinsic(byte[] encodedMethodBytes,
                                        string module, string method, Address sender, string privateKey,
                                       Action<string> callback);

        /// <summary>
        /// Unsubscribe from WebSocket endpoint and stop receiving updates with most recent Runtime Version.
        /// </summary>
        /// <param name="id"> Subscription id </param>
        void UnsubscribeRuntimeVersion(string id);

        /// <summary>
        /// Unsubscribe from WebSocket endpoint and stop receiving updates for address nonce.
        /// </summary>
        /// <param name="id"> Subscription id </param>
        void UnsubscribeAccountNonce(string id);

        /// <summary>
        /// Unsubscribe from WebSocket endpoint and stop receiving updates with era and session.
        /// </summary>
        /// <param name="id"> Subscription id </param>
        void UnsubscribeEraAndSession(string id);

        /// <summary>
        /// Unsubscribe from WebSocket endpoint and stop receiving updates for address balance.
        /// </summary>
        /// <param name="id"> Subscription id </param>
        void UnsubscribeStorage(string id);

        /// <summary>
        /// Unsubscribe from WebSocket endpoint and stop receiving updates for address balance.
        /// </summary>
        /// <param name="id"> Subscription id </param>
        void UnsubscribeBalance(string id);
    }
}
