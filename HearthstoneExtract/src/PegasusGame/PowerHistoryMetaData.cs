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
    public sealed class PowerHistoryMetaData : GeneratedMessageLite<PowerHistoryMetaData, Builder>
    {
        private static readonly string[] _powerHistoryMetaDataFieldNames = new string[] { "data", "info", "meta_type", "type" };
        private static readonly uint[] _powerHistoryMetaDataFieldTags = new uint[] { 0x20, 0x12, 0x18, 8 };
        private int data_;
        public const int DataFieldNumber = 4;
        private static readonly PowerHistoryMetaData defaultInstance = new PowerHistoryMetaData().MakeReadOnly();
        private bool hasData;
        private bool hasMetaType;
        private bool hasType;
        private PopsicleList<int> info_ = new PopsicleList<int>();
        public const int InfoFieldNumber = 2;
        private int infoMemoizedSerializedSize;
        private int memoizedSerializedSize = -1;
        private PegasusGame.PowerHistoryMetaData.Types.MetaType metaType_;
        public const int MetaTypeFieldNumber = 3;
        private int type_;
        public const int TypeFieldNumber = 1;

        static PowerHistoryMetaData()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PowerHistoryMetaData()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PowerHistoryMetaData prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PowerHistoryMetaData data = obj as PowerHistoryMetaData;
            if (data == null)
            {
                return false;
            }
            if ((this.hasType != data.hasType) || (this.hasType && !this.type_.Equals(data.type_)))
            {
                return false;
            }
            if (this.info_.Count != data.info_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.info_.Count; i++)
            {
                int num2 = this.info_[i];
                if (!num2.Equals(data.info_[i]))
                {
                    return false;
                }
            }
            if ((this.hasMetaType != data.hasMetaType) || (this.hasMetaType && !this.metaType_.Equals(data.metaType_)))
            {
                return false;
            }
            return ((this.hasData == data.hasData) && (!this.hasData || this.data_.Equals(data.data_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            IEnumerator<int> enumerator = this.info_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
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
            if (this.hasMetaType)
            {
                hashCode ^= this.metaType_.GetHashCode();
            }
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            return hashCode;
        }

        public int GetInfo(int index)
        {
            return this.info_[index];
        }

        private PowerHistoryMetaData MakeReadOnly()
        {
            this.info_.MakeReadOnly();
            return this;
        }

        public static PowerHistoryMetaData ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PowerHistoryMetaData ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryMetaData ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryMetaData ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryMetaData ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryMetaData ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryMetaData ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryMetaData ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryMetaData ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryMetaData ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PowerHistoryMetaData, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<PowerHistoryMetaData, Builder>.PrintField<int>("info", this.info_, writer);
            GeneratedMessageLite<PowerHistoryMetaData, Builder>.PrintField("meta_type", this.hasMetaType, this.metaType_, writer);
            GeneratedMessageLite<PowerHistoryMetaData, Builder>.PrintField("data", this.hasData, this.data_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _powerHistoryMetaDataFieldNames;
            if (this.hasType)
            {
                output.WriteInt32(1, strArray[3], this.Type);
            }
            if (this.info_.Count > 0)
            {
                output.WritePackedInt32Array(2, strArray[1], this.infoMemoizedSerializedSize, this.info_);
            }
            if (this.hasMetaType)
            {
                output.WriteEnum(3, strArray[2], (int) this.MetaType, this.MetaType);
            }
            if (this.hasData)
            {
                output.WriteInt32(4, strArray[0], this.Data);
            }
        }

        public int Data
        {
            get
            {
                return this.data_;
            }
        }

        public static PowerHistoryMetaData DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PowerHistoryMetaData DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasData
        {
            get
            {
                return this.hasData;
            }
        }

        public bool HasMetaType
        {
            get
            {
                return this.hasMetaType;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public int InfoCount
        {
            get
            {
                return this.info_.Count;
            }
        }

        public IList<int> InfoList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.info_);
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public PegasusGame.PowerHistoryMetaData.Types.MetaType MetaType
        {
            get
            {
                return this.metaType_;
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
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Type);
                    }
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.InfoList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            int current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeInt32SizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.info_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.infoMemoizedSerializedSize = num2;
                    if (this.hasMetaType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(3, (int) this.MetaType);
                    }
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Data);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PowerHistoryMetaData ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Type
        {
            get
            {
                return this.type_;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<PowerHistoryMetaData, PowerHistoryMetaData.Builder>
        {
            private PowerHistoryMetaData result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PowerHistoryMetaData.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PowerHistoryMetaData cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public PowerHistoryMetaData.Builder AddInfo(int value)
            {
                this.PrepareBuilder();
                this.result.info_.Add(value);
                return this;
            }

            public PowerHistoryMetaData.Builder AddRangeInfo(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.info_.Add(values);
                return this;
            }

            public override PowerHistoryMetaData BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PowerHistoryMetaData.Builder Clear()
            {
                this.result = PowerHistoryMetaData.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PowerHistoryMetaData.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = 0;
                return this;
            }

            public PowerHistoryMetaData.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.info_.Clear();
                return this;
            }

            public PowerHistoryMetaData.Builder ClearMetaType()
            {
                this.PrepareBuilder();
                this.result.hasMetaType = false;
                this.result.metaType_ = PegasusGame.PowerHistoryMetaData.Types.MetaType.META_TARGET;
                return this;
            }

            public PowerHistoryMetaData.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = 0;
                return this;
            }

            public override PowerHistoryMetaData.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PowerHistoryMetaData.Builder(this.result);
                }
                return new PowerHistoryMetaData.Builder().MergeFrom(this.result);
            }

            public int GetInfo(int index)
            {
                return this.result.GetInfo(index);
            }

            public override PowerHistoryMetaData.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PowerHistoryMetaData.Builder MergeFrom(IMessageLite other)
            {
                if (other is PowerHistoryMetaData)
                {
                    return this.MergeFrom((PowerHistoryMetaData) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PowerHistoryMetaData.Builder MergeFrom(PowerHistoryMetaData other)
            {
                if (other != PowerHistoryMetaData.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.info_.Count != 0)
                    {
                        this.result.info_.Add(other.info_);
                    }
                    if (other.HasMetaType)
                    {
                        this.MetaType = other.MetaType;
                    }
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                }
                return this;
            }

            public override PowerHistoryMetaData.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PowerHistoryMetaData._powerHistoryMetaDataFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PowerHistoryMetaData._powerHistoryMetaDataFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x10:
                        case 0x12:
                        {
                            input.ReadInt32Array(num, str, this.result.info_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
                            goto Label_00B0;

                        case 0x18:
                            goto Label_00E9;

                        case 0x20:
                            goto Label_0122;

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
                Label_00B0:
                    this.result.hasType = input.ReadInt32(ref this.result.type_);
                    continue;
                Label_00E9:
                    if (input.ReadEnum<PegasusGame.PowerHistoryMetaData.Types.MetaType>(ref this.result.metaType_, out obj2))
                    {
                        this.result.hasMetaType = true;
                    }
                    else if (!(obj2 is int))
                    {
                    }
                    continue;
                Label_0122:
                    this.result.hasData = input.ReadInt32(ref this.result.data_);
                }
                return this;
            }

            private PowerHistoryMetaData PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PowerHistoryMetaData result = this.result;
                    this.result = new PowerHistoryMetaData();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PowerHistoryMetaData.Builder SetData(int value)
            {
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            public PowerHistoryMetaData.Builder SetInfo(int index, int value)
            {
                this.PrepareBuilder();
                this.result.info_[index] = value;
                return this;
            }

            public PowerHistoryMetaData.Builder SetMetaType(PegasusGame.PowerHistoryMetaData.Types.MetaType value)
            {
                this.PrepareBuilder();
                this.result.hasMetaType = true;
                this.result.metaType_ = value;
                return this;
            }

            public PowerHistoryMetaData.Builder SetType(int value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public int Data
            {
                get
                {
                    return this.result.Data;
                }
                set
                {
                    this.SetData(value);
                }
            }

            public override PowerHistoryMetaData DefaultInstanceForType
            {
                get
                {
                    return PowerHistoryMetaData.DefaultInstance;
                }
            }

            public bool HasData
            {
                get
                {
                    return this.result.hasData;
                }
            }

            public bool HasMetaType
            {
                get
                {
                    return this.result.hasMetaType;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public int InfoCount
            {
                get
                {
                    return this.result.InfoCount;
                }
            }

            public IPopsicleList<int> InfoList
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

            protected override PowerHistoryMetaData MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public PegasusGame.PowerHistoryMetaData.Types.MetaType MetaType
            {
                get
                {
                    return this.result.MetaType;
                }
                set
                {
                    this.SetMetaType(value);
                }
            }

            protected override PowerHistoryMetaData.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Type
            {
                get
                {
                    return this.result.Type;
                }
                set
                {
                    this.SetType(value);
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum MetaType
            {
                META_TARGET,
                META_DAMAGE,
                META_HEALING
            }
        }
    }
}

