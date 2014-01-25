namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ClientOptions : GeneratedMessageLite<ClientOptions, Builder>
    {
        private static readonly string[] _clientOptionsFieldNames = new string[] { "options" };
        private static readonly uint[] _clientOptionsFieldTags = new uint[] { 10 };
        private static readonly ClientOptions defaultInstance = new ClientOptions().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<ClientOption> options_ = new PopsicleList<ClientOption>();
        public const int OptionsFieldNumber = 1;

        static ClientOptions()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ClientOptions()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ClientOptions prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ClientOptions options = obj as ClientOptions;
            if (options == null)
            {
                return false;
            }
            if (this.options_.Count != options.options_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.options_.Count; i++)
            {
                if (!this.options_[i].Equals(options.options_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<ClientOption> enumerator = this.options_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ClientOption current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        public ClientOption GetOptions(int index)
        {
            return this.options_[index];
        }

        private ClientOptions MakeReadOnly()
        {
            this.options_.MakeReadOnly();
            return this;
        }

        public static ClientOptions ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ClientOptions ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientOptions ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientOptions ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientOptions ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientOptions ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ClientOptions ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ClientOptions, Builder>.PrintField<ClientOption>("options", this.options_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _clientOptionsFieldNames;
            if (this.options_.Count > 0)
            {
                output.WriteMessageArray<ClientOption>(1, strArray[0], this.options_);
            }
        }

        public static ClientOptions DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ClientOptions DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<ClientOption> enumerator = this.OptionsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ClientOption current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                return true;
            }
        }

        public int OptionsCount
        {
            get
            {
                return this.options_.Count;
            }
        }

        public IList<ClientOption> OptionsList
        {
            get
            {
                return this.options_;
            }
        }

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<ClientOption> enumerator = this.OptionsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ClientOption current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ClientOptions ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ClientOptions, ClientOptions.Builder>
        {
            private ClientOptions result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ClientOptions.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ClientOptions cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ClientOptions.Builder AddOptions(ClientOption value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.options_.Add(value);
                return this;
            }

            public ClientOptions.Builder AddOptions(ClientOption.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.options_.Add(builderForValue.Build());
                return this;
            }

            public ClientOptions.Builder AddRangeOptions(IEnumerable<ClientOption> values)
            {
                this.PrepareBuilder();
                this.result.options_.Add(values);
                return this;
            }

            public override ClientOptions BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ClientOptions.Builder Clear()
            {
                this.result = ClientOptions.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ClientOptions.Builder ClearOptions()
            {
                this.PrepareBuilder();
                this.result.options_.Clear();
                return this;
            }

            public override ClientOptions.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ClientOptions.Builder(this.result);
                }
                return new ClientOptions.Builder().MergeFrom(this.result);
            }

            public ClientOption GetOptions(int index)
            {
                return this.result.GetOptions(index);
            }

            public override ClientOptions.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ClientOptions.Builder MergeFrom(IMessageLite other)
            {
                if (other is ClientOptions)
                {
                    return this.MergeFrom((ClientOptions) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ClientOptions.Builder MergeFrom(ClientOptions other)
            {
                if (other != ClientOptions.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.options_.Count != 0)
                    {
                        this.result.options_.Add(other.options_);
                    }
                }
                return this;
            }

            public override ClientOptions.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ClientOptions._clientOptionsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ClientOptions._clientOptionsFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 10:
                            break;

                        default:
                        {
                            if (WireFormat.IsEndGroupTag(num))
                            {
                                return this;
                            }
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    input.ReadMessageArray<ClientOption>(num, str, this.result.options_, ClientOption.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private ClientOptions PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ClientOptions result = this.result;
                    this.result = new ClientOptions();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ClientOptions.Builder SetOptions(int index, ClientOption value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.options_[index] = value;
                return this;
            }

            public ClientOptions.Builder SetOptions(int index, ClientOption.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.options_[index] = builderForValue.Build();
                return this;
            }

            public override ClientOptions DefaultInstanceForType
            {
                get
                {
                    return ClientOptions.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ClientOptions MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int OptionsCount
            {
                get
                {
                    return this.result.OptionsCount;
                }
            }

            public IPopsicleList<ClientOption> OptionsList
            {
                get
                {
                    return this.PrepareBuilder().options_;
                }
            }

            protected override ClientOptions.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xf1
            }
        }
    }
}

