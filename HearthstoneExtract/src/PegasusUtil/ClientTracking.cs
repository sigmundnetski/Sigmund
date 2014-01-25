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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ClientTracking : GeneratedMessageLite<ClientTracking, Builder>
    {
        private static readonly string[] _clientTrackingFieldNames = new string[] { "info" };
        private static readonly uint[] _clientTrackingFieldTags = new uint[] { 0x22 };
        private static readonly ClientTracking defaultInstance = new ClientTracking().MakeReadOnly();
        private PopsicleList<OneClientTracking> info_ = new PopsicleList<OneClientTracking>();
        public const int InfoFieldNumber = 4;
        private int memoizedSerializedSize = -1;

        static ClientTracking()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ClientTracking()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ClientTracking prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ClientTracking tracking = obj as ClientTracking;
            if (tracking == null)
            {
                return false;
            }
            if (this.info_.Count != tracking.info_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.info_.Count; i++)
            {
                if (!this.info_[i].Equals(tracking.info_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<OneClientTracking> enumerator = this.info_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    OneClientTracking current = enumerator.Current;
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

        public OneClientTracking GetInfo(int index)
        {
            return this.info_[index];
        }

        private ClientTracking MakeReadOnly()
        {
            this.info_.MakeReadOnly();
            return this;
        }

        public static ClientTracking ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ClientTracking ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientTracking ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientTracking ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientTracking ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientTracking ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientTracking ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ClientTracking ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientTracking ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientTracking ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ClientTracking, Builder>.PrintField<OneClientTracking>("info", this.info_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _clientTrackingFieldNames;
            if (this.info_.Count > 0)
            {
                output.WriteMessageArray<OneClientTracking>(4, strArray[0], this.info_);
            }
        }

        public static ClientTracking DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ClientTracking DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int InfoCount
        {
            get
            {
                return this.info_.Count;
            }
        }

        public IList<OneClientTracking> InfoList
        {
            get
            {
                return this.info_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<OneClientTracking> enumerator = this.InfoList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        OneClientTracking current = enumerator.Current;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<OneClientTracking> enumerator = this.InfoList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            OneClientTracking current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, current);
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

        protected override ClientTracking ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ClientTracking, ClientTracking.Builder>
        {
            private ClientTracking result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ClientTracking.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ClientTracking cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ClientTracking.Builder AddInfo(OneClientTracking value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.info_.Add(value);
                return this;
            }

            public ClientTracking.Builder AddInfo(OneClientTracking.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.info_.Add(builderForValue.Build());
                return this;
            }

            public ClientTracking.Builder AddRangeInfo(IEnumerable<OneClientTracking> values)
            {
                this.PrepareBuilder();
                this.result.info_.Add(values);
                return this;
            }

            public override ClientTracking BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ClientTracking.Builder Clear()
            {
                this.result = ClientTracking.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ClientTracking.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.info_.Clear();
                return this;
            }

            public override ClientTracking.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ClientTracking.Builder(this.result);
                }
                return new ClientTracking.Builder().MergeFrom(this.result);
            }

            public OneClientTracking GetInfo(int index)
            {
                return this.result.GetInfo(index);
            }

            public override ClientTracking.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ClientTracking.Builder MergeFrom(IMessageLite other)
            {
                if (other is ClientTracking)
                {
                    return this.MergeFrom((ClientTracking) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ClientTracking.Builder MergeFrom(ClientTracking other)
            {
                if (other != ClientTracking.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.info_.Count != 0)
                    {
                        this.result.info_.Add(other.info_);
                    }
                }
                return this;
            }

            public override ClientTracking.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ClientTracking._clientTrackingFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ClientTracking._clientTrackingFieldTags[index];
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

                        case 0x22:
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
                    input.ReadMessageArray<OneClientTracking>(num, str, this.result.info_, OneClientTracking.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private ClientTracking PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ClientTracking result = this.result;
                    this.result = new ClientTracking();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ClientTracking.Builder SetInfo(int index, OneClientTracking value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.info_[index] = value;
                return this;
            }

            public ClientTracking.Builder SetInfo(int index, OneClientTracking.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.info_[index] = builderForValue.Build();
                return this;
            }

            public override ClientTracking DefaultInstanceForType
            {
                get
                {
                    return ClientTracking.DefaultInstance;
                }
            }

            public int InfoCount
            {
                get
                {
                    return this.result.InfoCount;
                }
            }

            public IPopsicleList<OneClientTracking> InfoList
            {
                get
                {
                    return this.PrepareBuilder().info_;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ClientTracking MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ClientTracking.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xe4,
                System = 0
            }
        }
    }
}

