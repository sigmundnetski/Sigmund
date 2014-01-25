namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class PowerHistory : GeneratedMessageLite<PowerHistory, Builder>
    {
        private static readonly string[] _powerHistoryFieldNames = new string[] { "list" };
        private static readonly uint[] _powerHistoryFieldTags = new uint[] { 10 };
        private static readonly PowerHistory defaultInstance = new PowerHistory().MakeReadOnly();
        private PopsicleList<PowerHistoryData> list_ = new PopsicleList<PowerHistoryData>();
        public const int ListFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static PowerHistory()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PowerHistory()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PowerHistory prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PowerHistory history = obj as PowerHistory;
            if (history == null)
            {
                return false;
            }
            if (this.list_.Count != history.list_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.list_.Count; i++)
            {
                if (!this.list_[i].Equals(history.list_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<PowerHistoryData> enumerator = this.list_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    PowerHistoryData current = enumerator.Current;
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

        public PowerHistoryData GetList(int index)
        {
            return this.list_[index];
        }

        private PowerHistory MakeReadOnly()
        {
            this.list_.MakeReadOnly();
            return this;
        }

        public static PowerHistory ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PowerHistory ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistory ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistory ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistory ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistory ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistory ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PowerHistory ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistory ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistory ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PowerHistory, Builder>.PrintField<PowerHistoryData>("list", this.list_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _powerHistoryFieldNames;
            if (this.list_.Count > 0)
            {
                output.WriteMessageArray<PowerHistoryData>(1, strArray[0], this.list_);
            }
        }

        public static PowerHistory DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PowerHistory DefaultInstanceForType
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
                IEnumerator<PowerHistoryData> enumerator = this.ListList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        PowerHistoryData current = enumerator.Current;
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

        public int ListCount
        {
            get
            {
                return this.list_.Count;
            }
        }

        public IList<PowerHistoryData> ListList
        {
            get
            {
                return this.list_;
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
                    IEnumerator<PowerHistoryData> enumerator = this.ListList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            PowerHistoryData current = enumerator.Current;
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

        protected override PowerHistory ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<PowerHistory, PowerHistory.Builder>
        {
            private PowerHistory result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PowerHistory.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PowerHistory cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public PowerHistory.Builder AddList(PowerHistoryData value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_.Add(value);
                return this;
            }

            public PowerHistory.Builder AddList(PowerHistoryData.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_.Add(builderForValue.Build());
                return this;
            }

            public PowerHistory.Builder AddRangeList(IEnumerable<PowerHistoryData> values)
            {
                this.PrepareBuilder();
                this.result.list_.Add(values);
                return this;
            }

            public override PowerHistory BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PowerHistory.Builder Clear()
            {
                this.result = PowerHistory.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PowerHistory.Builder ClearList()
            {
                this.PrepareBuilder();
                this.result.list_.Clear();
                return this;
            }

            public override PowerHistory.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PowerHistory.Builder(this.result);
                }
                return new PowerHistory.Builder().MergeFrom(this.result);
            }

            public PowerHistoryData GetList(int index)
            {
                return this.result.GetList(index);
            }

            public override PowerHistory.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PowerHistory.Builder MergeFrom(IMessageLite other)
            {
                if (other is PowerHistory)
                {
                    return this.MergeFrom((PowerHistory) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PowerHistory.Builder MergeFrom(PowerHistory other)
            {
                if (other != PowerHistory.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.list_.Count != 0)
                    {
                        this.result.list_.Add(other.list_);
                    }
                }
                return this;
            }

            public override PowerHistory.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PowerHistory._powerHistoryFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PowerHistory._powerHistoryFieldTags[index];
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
                    input.ReadMessageArray<PowerHistoryData>(num, str, this.result.list_, PowerHistoryData.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private PowerHistory PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PowerHistory result = this.result;
                    this.result = new PowerHistory();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PowerHistory.Builder SetList(int index, PowerHistoryData value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_[index] = value;
                return this;
            }

            public PowerHistory.Builder SetList(int index, PowerHistoryData.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_[index] = builderForValue.Build();
                return this;
            }

            public override PowerHistory DefaultInstanceForType
            {
                get
                {
                    return PowerHistory.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int ListCount
            {
                get
                {
                    return this.result.ListCount;
                }
            }

            public IPopsicleList<PowerHistoryData> ListList
            {
                get
                {
                    return this.PrepareBuilder().list_;
                }
            }

            protected override PowerHistory MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PowerHistory.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x13
            }
        }
    }
}

