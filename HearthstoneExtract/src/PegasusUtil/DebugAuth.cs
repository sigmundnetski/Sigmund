namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class DebugAuth : GeneratedMessageLite<DebugAuth, Builder>
    {
        private static readonly string[] _debugAuthFieldNames = new string[] { "player_id", "result" };
        private static readonly uint[] _debugAuthFieldTags = new uint[] { 0x10, 8 };
        private static readonly DebugAuth defaultInstance = new DebugAuth().MakeReadOnly();
        private bool hasPlayerId;
        private bool hasResult;
        private int memoizedSerializedSize = -1;
        private long playerId_;
        public const int PlayerIdFieldNumber = 2;
        private PegasusUtil.DebugAuth.Types.Result result_;
        public const int ResultFieldNumber = 1;

        static DebugAuth()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DebugAuth()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugAuth prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugAuth auth = obj as DebugAuth;
            if (auth == null)
            {
                return false;
            }
            if ((this.hasResult != auth.hasResult) || (this.hasResult && !this.result_.Equals(auth.result_)))
            {
                return false;
            }
            return ((this.hasPlayerId == auth.hasPlayerId) && (!this.hasPlayerId || this.playerId_.Equals(auth.playerId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasResult)
            {
                hashCode ^= this.result_.GetHashCode();
            }
            if (this.hasPlayerId)
            {
                hashCode ^= this.playerId_.GetHashCode();
            }
            return hashCode;
        }

        private DebugAuth MakeReadOnly()
        {
            return this;
        }

        public static DebugAuth ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugAuth ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugAuth ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugAuth ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugAuth ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugAuth ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugAuth ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugAuth ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugAuth ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugAuth ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugAuth, Builder>.PrintField("result", this.hasResult, this.result_, writer);
            GeneratedMessageLite<DebugAuth, Builder>.PrintField("player_id", this.hasPlayerId, this.playerId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugAuthFieldNames;
            if (this.hasResult)
            {
                output.WriteEnum(1, strArray[1], (int) this.Result, this.Result);
            }
            if (this.hasPlayerId)
            {
                output.WriteInt64(2, strArray[0], this.PlayerId);
            }
        }

        public static DebugAuth DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugAuth DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasPlayerId
        {
            get
            {
                return this.hasPlayerId;
            }
        }

        public bool HasResult
        {
            get
            {
                return this.hasResult;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasResult)
                {
                    return false;
                }
                if (!this.hasPlayerId)
                {
                    return false;
                }
                return true;
            }
        }

        public long PlayerId
        {
            get
            {
                return this.playerId_;
            }
        }

        public PegasusUtil.DebugAuth.Types.Result Result
        {
            get
            {
                return this.result_;
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
                    if (this.hasResult)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Result);
                    }
                    if (this.hasPlayerId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(2, this.PlayerId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DebugAuth ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DebugAuth, DebugAuth.Builder>
        {
            private DebugAuth result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugAuth.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugAuth cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DebugAuth BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugAuth.Builder Clear()
            {
                this.result = DebugAuth.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugAuth.Builder ClearPlayerId()
            {
                this.PrepareBuilder();
                this.result.hasPlayerId = false;
                this.result.playerId_ = 0L;
                return this;
            }

            public DebugAuth.Builder ClearResult()
            {
                this.PrepareBuilder();
                this.result.hasResult = false;
                this.result.result_ = PegasusUtil.DebugAuth.Types.Result.UNKNOWN;
                return this;
            }

            public override DebugAuth.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugAuth.Builder(this.result);
                }
                return new DebugAuth.Builder().MergeFrom(this.result);
            }

            public override DebugAuth.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugAuth.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugAuth)
                {
                    return this.MergeFrom((DebugAuth) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugAuth.Builder MergeFrom(DebugAuth other)
            {
                if (other != DebugAuth.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasResult)
                    {
                        this.Result = other.Result;
                    }
                    if (other.HasPlayerId)
                    {
                        this.PlayerId = other.PlayerId;
                    }
                }
                return this;
            }

            public override DebugAuth.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugAuth._debugAuthFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugAuth._debugAuthFieldTags[index];
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
                        {
                            object obj2;
                            if (input.ReadEnum<PegasusUtil.DebugAuth.Types.Result>(ref this.result.result_, out obj2))
                            {
                                this.result.hasResult = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasPlayerId = input.ReadInt64(ref this.result.playerId_);
                }
                return this;
            }

            private DebugAuth PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugAuth result = this.result;
                    this.result = new DebugAuth();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugAuth.Builder SetPlayerId(long value)
            {
                this.PrepareBuilder();
                this.result.hasPlayerId = true;
                this.result.playerId_ = value;
                return this;
            }

            public DebugAuth.Builder SetResult(PegasusUtil.DebugAuth.Types.Result value)
            {
                this.PrepareBuilder();
                this.result.hasResult = true;
                this.result.result_ = value;
                return this;
            }

            public override DebugAuth DefaultInstanceForType
            {
                get
                {
                    return DebugAuth.DefaultInstance;
                }
            }

            public bool HasPlayerId
            {
                get
                {
                    return this.result.hasPlayerId;
                }
            }

            public bool HasResult
            {
                get
                {
                    return this.result.hasResult;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DebugAuth MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public long PlayerId
            {
                get
                {
                    return this.result.PlayerId;
                }
                set
                {
                    this.SetPlayerId(value);
                }
            }

            public PegasusUtil.DebugAuth.Types.Result Result
            {
                get
                {
                    return this.result.Result;
                }
                set
                {
                    this.SetResult(value);
                }
            }

            protected override DebugAuth.Builder ThisBuilder
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
                ID = 0xce
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Result
            {
                UNKNOWN,
                VALID,
                BAD_USER,
                BAD_PASSWORD
            }
        }
    }
}

