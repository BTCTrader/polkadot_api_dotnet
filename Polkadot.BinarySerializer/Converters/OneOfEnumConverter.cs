﻿using System;
using System.IO;
using System.Linq;
using OneOf;
using Polkadot.BinarySerializer.Extensions;

namespace Polkadot.BinarySerializer.Converters
{
    public class OneOfEnumConverter : IBinaryConverter
    {
        public void Serialize(Stream stream, object value, IBinarySerializer serializer, object[] parameters)
        {
            var innerValue = ((IOneOf) value).Value;
            var index = (int) value.GetType().GetField("_index").GetValue(value);
            stream.WriteByte((byte)index);
            serializer.Serialize(innerValue);
        }

        public object Deserialize(Type type, Stream stream, IBinarySerializer deserializer, object[] parameters)
        {
            var index = stream.ReadByteThrowIfStreamEnd();
            var innerType = type.GetGenericArguments()[index];
            var innerValue = deserializer.Deserialize(innerType, stream);
            var cast = type.GetMethod("op_Implicit", new[] {innerType});
            return cast!.Invoke(null, new[] {innerValue});
        }
    }
}