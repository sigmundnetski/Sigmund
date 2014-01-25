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

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class PlayerRecords : GeneratedMessageLite<PlayerRecords, Builder>
    {
        private static readonly string[] _playerRecordsFieldNames = new string[] { "records" };
        private static readonly uint[] _playerRecordsFieldTags = new uint[] { 10 };
        private static readonly PlayerRecords defaultInstance = new PlayerRecords().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<PlayerRecord> records_ = new PopsicleList<PlayerRecord>();
        public const int RecordsFieldNumber = 1;

        static PlayerRecords()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private PlayerRecords()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PlayerRecords prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PlayerRecords records = obj as PlayerRecords;
            if (records == null)
            {
                return false;
            }
            if (this.records_.Count != records.records_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.records_.Count; i++)
            {
                if (!this.records_[i].Equals(records.records_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<PlayerRecord> enumerator = this.records_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    PlayerRecord current = enumerator.Current;
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

        public PlayerRecord GetRecords(int index)
        {
            return this.records_[index];
        }

        private PlayerRecords MakeReadOnly()
        {
            this.records_.MakeReadOnly();
            return this;
        }

        public static PlayerRecords ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PlayerRecords ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerRecords ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerRecords ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerRecords ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerRecords ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerRecords ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PlayerRecords ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerRecords ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerRecords ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PlayerRecords, Builder>.PrintField<PlayerRecord>("records", this.records_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _playerRecordsFieldNames;
            if (this.records_.Count > 0)
            {
                output.WriteMessageArray<PlayerRecord>(1, strArray[0], this.records_);
            }
        }

        public static PlayerRecords DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PlayerRecords DefaultInstanceForType
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
                IEnumerator<PlayerRecord> enumerator = this.RecordsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        PlayerRecord current = enumerator.Current;
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

        public int RecordsCount
        {
            get
            {
                return this.records_.Count;
            }
        }

        public IList<PlayerRecord> RecordsList
        {
            get
            {
                return this.records_;
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
                    IEnumerator<PlayerRecord> enumerator = this.RecordsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            PlayerRecord current = enumerator.Current;
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

        protected override PlayerRecords ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<PlayerRecords, PlayerRecords.Builder>
        {
            private PlayerRecords result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PlayerRecords.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PlayerRecords cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public PlayerRecords.Builder AddRangeRecords(IEnumerable<PlayerRecord> values)
            {
                this.PrepareBuilder();
                this.result.records_.Add(values);
                return this;
            }

            public PlayerRecords.Builder AddRecords(PlayerRecord value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.records_.Add(value);
                return this;
            }

            public PlayerRecords.Builder AddRecords(PlayerRecord.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.records_.Add(builderForValue.Build());
                return this;
            }

            public override PlayerRecords BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PlayerRecords.Builder Clear()
            {
                this.result = PlayerRecords.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PlayerRecords.Builder ClearRecords()
            {
                this.PrepareBuilder();
                this.result.records_.Clear();
                return this;
            }

            public override PlayerRecords.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PlayerRecords.Builder(this.result);
                }
                return new PlayerRecords.Builder().MergeFrom(this.result);
            }

            public PlayerRecord GetRecords(int index)
            {
                return this.result.GetRecords(index);
            }

            public override PlayerRecords.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PlayerRecords.Builder MergeFrom(IMessageLite other)
            {
                if (other is PlayerRecords)
                {
                    return this.MergeFrom((PlayerRecords) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PlayerRecords.Builder MergeFrom(PlayerRecords other)
            {
                if (other != PlayerRecords.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.records_.Count != 0)
                    {
                        this.result.records_.Add(other.records_);
                    }
                }
                return this;
            }

            public override PlayerRecords.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PlayerRecords._playerRecordsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PlayerRecords._playerRecordsFieldTags[index];
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
                    input.ReadMessageArray<PlayerRecord>(num, str, this.result.records_, PlayerRecord.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private PlayerRecords PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PlayerRecords result = this.result;
                    this.result = new PlayerRecords();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PlayerRecords.Builder SetRecords(int index, PlayerRecord value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.records_[index] = value;
                return this;
            }

            public PlayerRecords.Builder SetRecords(int index, PlayerRecord.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.records_[index] = builderForValue.Build();
                return this;
            }

            public override PlayerRecords DefaultInstanceForType
            {
                get
                {
                    return PlayerRecords.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PlayerRecords MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int RecordsCount
            {
                get
                {
                    return this.result.RecordsCount;
                }
            }

            public IPopsicleList<PlayerRecord> RecordsList
            {
                get
                {
                    return this.PrepareBuilder().records_;
                }
            }

            protected override PlayerRecords.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 270
            }
        }
    }
}

