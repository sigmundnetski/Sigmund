namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DatabaseRenameProfile : GeneratedMessageLite<DatabaseRenameProfile, Builder>
    {
        private static readonly string[] _databaseRenameProfileFieldNames = new string[] { "name" };
        private static readonly uint[] _databaseRenameProfileFieldTags = new uint[] { 10 };
        private static readonly DatabaseRenameProfile defaultInstance = new DatabaseRenameProfile().MakeReadOnly();
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 1;

        static DatabaseRenameProfile()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseRenameProfile()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseRenameProfile prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseRenameProfile profile = obj as DatabaseRenameProfile;
            if (profile == null)
            {
                return false;
            }
            return ((this.hasName == profile.hasName) && (!this.hasName || this.name_.Equals(profile.name_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            return hashCode;
        }

        private DatabaseRenameProfile MakeReadOnly()
        {
            return this;
        }

        public static DatabaseRenameProfile ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseRenameProfile ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseRenameProfile ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseRenameProfile ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseRenameProfile ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseRenameProfile ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseRenameProfile ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseRenameProfile ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseRenameProfile ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseRenameProfile ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseRenameProfile, Builder>.PrintField("name", this.hasName, this.name_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseRenameProfileFieldNames;
            if (this.hasName)
            {
                output.WriteString(1, strArray[0], this.Name);
            }
        }

        public static DatabaseRenameProfile DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseRenameProfile DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasName)
                {
                    return false;
                }
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
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
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Name);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseRenameProfile ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DatabaseRenameProfile, DatabaseRenameProfile.Builder>
        {
            private DatabaseRenameProfile result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseRenameProfile.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseRenameProfile cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseRenameProfile BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseRenameProfile.Builder Clear()
            {
                this.result = DatabaseRenameProfile.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseRenameProfile.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public override DatabaseRenameProfile.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseRenameProfile.Builder(this.result);
                }
                return new DatabaseRenameProfile.Builder().MergeFrom(this.result);
            }

            public override DatabaseRenameProfile.Builder MergeFrom(DatabaseRenameProfile other)
            {
                if (other != DatabaseRenameProfile.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                }
                return this;
            }

            public override DatabaseRenameProfile.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseRenameProfile.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseRenameProfile)
                {
                    return this.MergeFrom((DatabaseRenameProfile) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseRenameProfile.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseRenameProfile._databaseRenameProfileFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseRenameProfile._databaseRenameProfileFieldTags[index];
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
                    this.result.hasName = input.ReadString(ref this.result.name_);
                }
                return this;
            }

            private DatabaseRenameProfile PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseRenameProfile result = this.result;
                    this.result = new DatabaseRenameProfile();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseRenameProfile.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public override DatabaseRenameProfile DefaultInstanceForType
            {
                get
                {
                    return DatabaseRenameProfile.DefaultInstance;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DatabaseRenameProfile MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Name
            {
                get
                {
                    return this.result.Name;
                }
                set
                {
                    this.SetName(value);
                }
            }

            protected override DatabaseRenameProfile.Builder ThisBuilder
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
                ID = 0x8a
            }
        }
    }
}

