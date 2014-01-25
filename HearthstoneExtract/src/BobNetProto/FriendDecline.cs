namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class FriendDecline : GeneratedMessageLite<FriendDecline, Builder>
    {
        private static readonly string[] _friendDeclineFieldNames = new string[] { "bn_game_handle" };
        private static readonly uint[] _friendDeclineFieldTags = new uint[] { 8 };
        private int bnGameHandle_;
        public const int BnGameHandleFieldNumber = 1;
        private static readonly FriendDecline defaultInstance = new FriendDecline().MakeReadOnly();
        private bool hasBnGameHandle;
        private int memoizedSerializedSize = -1;

        static FriendDecline()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private FriendDecline()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FriendDecline prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FriendDecline decline = obj as FriendDecline;
            if (decline == null)
            {
                return false;
            }
            return ((this.hasBnGameHandle == decline.hasBnGameHandle) && (!this.hasBnGameHandle || this.bnGameHandle_.Equals(decline.bnGameHandle_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBnGameHandle)
            {
                hashCode ^= this.bnGameHandle_.GetHashCode();
            }
            return hashCode;
        }

        private FriendDecline MakeReadOnly()
        {
            return this;
        }

        public static FriendDecline ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FriendDecline ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendDecline ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FriendDecline ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FriendDecline ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FriendDecline ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FriendDecline ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FriendDecline ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendDecline ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendDecline ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FriendDecline, Builder>.PrintField("bn_game_handle", this.hasBnGameHandle, this.bnGameHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _friendDeclineFieldNames;
            if (this.hasBnGameHandle)
            {
                output.WriteInt32(1, strArray[0], this.BnGameHandle);
            }
        }

        public int BnGameHandle
        {
            get
            {
                return this.bnGameHandle_;
            }
        }

        public static FriendDecline DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FriendDecline DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBnGameHandle
        {
            get
            {
                return this.hasBnGameHandle;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasBnGameHandle)
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
                    if (this.hasBnGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.BnGameHandle);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override FriendDecline ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<FriendDecline, FriendDecline.Builder>
        {
            private FriendDecline result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FriendDecline.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FriendDecline cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FriendDecline BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FriendDecline.Builder Clear()
            {
                this.result = FriendDecline.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FriendDecline.Builder ClearBnGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = false;
                this.result.bnGameHandle_ = 0;
                return this;
            }

            public override FriendDecline.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FriendDecline.Builder(this.result);
                }
                return new FriendDecline.Builder().MergeFrom(this.result);
            }

            public override FriendDecline.Builder MergeFrom(FriendDecline other)
            {
                if (other != FriendDecline.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBnGameHandle)
                    {
                        this.BnGameHandle = other.BnGameHandle;
                    }
                }
                return this;
            }

            public override FriendDecline.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FriendDecline.Builder MergeFrom(IMessageLite other)
            {
                if (other is FriendDecline)
                {
                    return this.MergeFrom((FriendDecline) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FriendDecline.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FriendDecline._friendDeclineFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FriendDecline._friendDeclineFieldTags[index];
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
                    this.result.hasBnGameHandle = input.ReadInt32(ref this.result.bnGameHandle_);
                }
                return this;
            }

            private FriendDecline PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FriendDecline result = this.result;
                    this.result = new FriendDecline();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FriendDecline.Builder SetBnGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = true;
                this.result.bnGameHandle_ = value;
                return this;
            }

            public int BnGameHandle
            {
                get
                {
                    return this.result.BnGameHandle;
                }
                set
                {
                    this.SetBnGameHandle(value);
                }
            }

            public override FriendDecline DefaultInstanceForType
            {
                get
                {
                    return FriendDecline.DefaultInstance;
                }
            }

            public bool HasBnGameHandle
            {
                get
                {
                    return this.result.hasBnGameHandle;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override FriendDecline MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override FriendDecline.Builder ThisBuilder
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
                ID = 0xa2
            }
        }
    }
}

