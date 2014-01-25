namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GetBattlePayStatus : GeneratedMessageLite<GetBattlePayStatus, Builder>
    {
        private static readonly string[] _getBattlePayStatusFieldNames = new string[0];
        private static readonly uint[] _getBattlePayStatusFieldTags = new uint[0];
        private static readonly GetBattlePayStatus defaultInstance = new GetBattlePayStatus().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static GetBattlePayStatus()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GetBattlePayStatus()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetBattlePayStatus prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is GetBattlePayStatus);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private GetBattlePayStatus MakeReadOnly()
        {
            return this;
        }

        public static GetBattlePayStatus ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetBattlePayStatus ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetBattlePayStatus ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetBattlePayStatus ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetBattlePayStatus ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetBattlePayStatus ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetBattlePayStatus ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetBattlePayStatus ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetBattlePayStatus ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetBattlePayStatus ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getBattlePayStatusFieldNames;
        }

        public static GetBattlePayStatus DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetBattlePayStatus DefaultInstanceForType
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetBattlePayStatus ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GetBattlePayStatus, GetBattlePayStatus.Builder>
        {
            private GetBattlePayStatus result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetBattlePayStatus.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetBattlePayStatus cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetBattlePayStatus BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetBattlePayStatus.Builder Clear()
            {
                this.result = GetBattlePayStatus.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override GetBattlePayStatus.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetBattlePayStatus.Builder(this.result);
                }
                return new GetBattlePayStatus.Builder().MergeFrom(this.result);
            }

            public override GetBattlePayStatus.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetBattlePayStatus.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetBattlePayStatus)
                {
                    return this.MergeFrom((GetBattlePayStatus) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetBattlePayStatus.Builder MergeFrom(GetBattlePayStatus other)
            {
                if (other != GetBattlePayStatus.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override GetBattlePayStatus.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetBattlePayStatus._getBattlePayStatusFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetBattlePayStatus._getBattlePayStatusFieldTags[index];
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
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private GetBattlePayStatus PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetBattlePayStatus result = this.result;
                    this.result = new GetBattlePayStatus();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override GetBattlePayStatus DefaultInstanceForType
            {
                get
                {
                    return GetBattlePayStatus.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetBattlePayStatus MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetBattlePayStatus.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xff,
                System = 1
            }
        }
    }
}

