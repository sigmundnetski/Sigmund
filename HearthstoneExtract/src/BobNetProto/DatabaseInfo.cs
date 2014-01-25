namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DatabaseInfo : GeneratedMessageLite<DatabaseInfo, Builder>
    {
        private static readonly string[] _databaseInfoFieldNames = new string[] { "info" };
        private static readonly uint[] _databaseInfoFieldTags = new uint[] { 8 };
        private static readonly DatabaseInfo defaultInstance = new DatabaseInfo().MakeReadOnly();
        private bool hasInfo;
        private Types.TInfo info_ = Types.TInfo.BAD_COMMAND;
        public const int InfoFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static DatabaseInfo()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseInfo info = obj as DatabaseInfo;
            if (info == null)
            {
                return false;
            }
            return ((this.hasInfo == info.hasInfo) && (!this.hasInfo || this.info_.Equals(info.info_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasInfo)
            {
                hashCode ^= this.info_.GetHashCode();
            }
            return hashCode;
        }

        private DatabaseInfo MakeReadOnly()
        {
            return this;
        }

        public static DatabaseInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseInfo, Builder>.PrintField("info", this.hasInfo, this.info_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseInfoFieldNames;
            if (this.hasInfo)
            {
                output.WriteEnum(1, strArray[0], (int) this.Info, this.Info);
            }
        }

        public static DatabaseInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasInfo
        {
            get
            {
                return this.hasInfo;
            }
        }

        public Types.TInfo Info
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
                if (!this.hasInfo)
                {
                    return false;
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
                    if (this.hasInfo)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Info);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DatabaseInfo, DatabaseInfo.Builder>
        {
            private DatabaseInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseInfo.Builder Clear()
            {
                this.result = DatabaseInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseInfo.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.hasInfo = false;
                this.result.info_ = DatabaseInfo.Types.TInfo.BAD_COMMAND;
                return this;
            }

            public override DatabaseInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseInfo.Builder(this.result);
                }
                return new DatabaseInfo.Builder().MergeFrom(this.result);
            }

            public override DatabaseInfo.Builder MergeFrom(DatabaseInfo other)
            {
                if (other != DatabaseInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasInfo)
                    {
                        this.Info = other.Info;
                    }
                }
                return this;
            }

            public override DatabaseInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseInfo)
                {
                    return this.MergeFrom((DatabaseInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseInfo._databaseInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseInfo._databaseInfoFieldTags[index];
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

                        case 8:
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
                    if (input.ReadEnum<DatabaseInfo.Types.TInfo>(ref this.result.info_, out obj2))
                    {
                        this.result.hasInfo = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private DatabaseInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseInfo result = this.result;
                    this.result = new DatabaseInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseInfo.Builder SetInfo(DatabaseInfo.Types.TInfo value)
            {
                this.PrepareBuilder();
                this.result.hasInfo = true;
                this.result.info_ = value;
                return this;
            }

            public override DatabaseInfo DefaultInstanceForType
            {
                get
                {
                    return DatabaseInfo.DefaultInstance;
                }
            }

            public bool HasInfo
            {
                get
                {
                    return this.result.hasInfo;
                }
            }

            public DatabaseInfo.Types.TInfo Info
            {
                get
                {
                    return this.result.Info;
                }
                set
                {
                    this.SetInfo(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DatabaseInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DatabaseInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x83
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum TInfo
            {
                BAD_COMMAND = 1,
                LOSS_ADDED = 3,
                PROFILE_ADDED = 4,
                WIN_ADDED = 2
            }
        }
    }
}

