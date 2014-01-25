namespace bnet.protocol.game_master
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
    public sealed class ChangeGameRequest : GeneratedMessageLite<ChangeGameRequest, Builder>
    {
        private static readonly string[] _changeGameRequestFieldNames = new string[] { "attribute", "game_handle", "open", "replace" };
        private static readonly uint[] _changeGameRequestFieldTags = new uint[] { 0x1a, 10, 0x10, 0x20 };
        private PopsicleList<bnet.protocol.game_master.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_master.Attribute>();
        public const int AttributeFieldNumber = 3;
        private static readonly ChangeGameRequest defaultInstance = new ChangeGameRequest().MakeReadOnly();
        private bnet.protocol.game_master.GameHandle gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasGameHandle;
        private bool hasOpen;
        private bool hasReplace;
        private int memoizedSerializedSize = -1;
        private bool open_;
        public const int OpenFieldNumber = 2;
        private bool replace_;
        public const int ReplaceFieldNumber = 4;

        static ChangeGameRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private ChangeGameRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ChangeGameRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ChangeGameRequest request = obj as ChangeGameRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasGameHandle != request.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(request.gameHandle_)))
            {
                return false;
            }
            if ((this.hasOpen != request.hasOpen) || (this.hasOpen && !this.open_.Equals(request.open_)))
            {
                return false;
            }
            if (this.attribute_.Count != request.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(request.attribute_[i]))
                {
                    return false;
                }
            }
            return ((this.hasReplace == request.hasReplace) && (!this.hasReplace || this.replace_.Equals(request.replace_)));
        }

        public bnet.protocol.game_master.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
            }
            if (this.hasOpen)
            {
                hashCode ^= this.open_.GetHashCode();
            }
            IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_master.Attribute current = enumerator.Current;
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
            if (this.hasReplace)
            {
                hashCode ^= this.replace_.GetHashCode();
            }
            return hashCode;
        }

        private ChangeGameRequest MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static ChangeGameRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ChangeGameRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChangeGameRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChangeGameRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChangeGameRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChangeGameRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChangeGameRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ChangeGameRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChangeGameRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChangeGameRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ChangeGameRequest, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<ChangeGameRequest, Builder>.PrintField("open", this.hasOpen, this.open_, writer);
            GeneratedMessageLite<ChangeGameRequest, Builder>.PrintField<bnet.protocol.game_master.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<ChangeGameRequest, Builder>.PrintField("replace", this.hasReplace, this.replace_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _changeGameRequestFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteMessage(1, strArray[1], this.GameHandle);
            }
            if (this.hasOpen)
            {
                output.WriteBool(2, strArray[2], this.Open);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_master.Attribute>(3, strArray[0], this.attribute_);
            }
            if (this.hasReplace)
            {
                output.WriteBool(4, strArray[3], this.Replace);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_master.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static ChangeGameRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ChangeGameRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bnet.protocol.game_master.GameHandle GameHandle
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameHandle_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.game_master.GameHandle.DefaultInstance;
            }
        }

        public bool HasGameHandle
        {
            get
            {
                return this.hasGameHandle;
            }
        }

        public bool HasOpen
        {
            get
            {
                return this.hasOpen;
            }
        }

        public bool HasReplace
        {
            get
            {
                return this.hasReplace;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameHandle)
                {
                    return false;
                }
                if (!this.GameHandle.IsInitialized)
                {
                    return false;
                }
                IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_master.Attribute current = enumerator.Current;
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

        public bool Open
        {
            get
            {
                return this.open_;
            }
        }

        public bool Replace
        {
            get
            {
                return this.replace_;
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
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.GameHandle);
                    }
                    if (this.hasOpen)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.Open);
                    }
                    IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_master.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    if (this.hasReplace)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(4, this.Replace);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ChangeGameRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ChangeGameRequest, ChangeGameRequest.Builder>
        {
            private ChangeGameRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ChangeGameRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ChangeGameRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ChangeGameRequest.Builder AddAttribute(bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public ChangeGameRequest.Builder AddAttribute(bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public ChangeGameRequest.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_master.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override ChangeGameRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ChangeGameRequest.Builder Clear()
            {
                this.result = ChangeGameRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ChangeGameRequest.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public ChangeGameRequest.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = null;
                return this;
            }

            public ChangeGameRequest.Builder ClearOpen()
            {
                this.PrepareBuilder();
                this.result.hasOpen = false;
                this.result.open_ = false;
                return this;
            }

            public ChangeGameRequest.Builder ClearReplace()
            {
                this.PrepareBuilder();
                this.result.hasReplace = false;
                this.result.replace_ = false;
                return this;
            }

            public override ChangeGameRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ChangeGameRequest.Builder(this.result);
                }
                return new ChangeGameRequest.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_master.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override ChangeGameRequest.Builder MergeFrom(ChangeGameRequest other)
            {
                if (other != ChangeGameRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.MergeGameHandle(other.GameHandle);
                    }
                    if (other.HasOpen)
                    {
                        this.Open = other.Open;
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.HasReplace)
                    {
                        this.Replace = other.Replace;
                    }
                }
                return this;
            }

            public override ChangeGameRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ChangeGameRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ChangeGameRequest)
                {
                    return this.MergeFrom((ChangeGameRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ChangeGameRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ChangeGameRequest._changeGameRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ChangeGameRequest._changeGameRequestFieldTags[index];
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
                        {
                            bnet.protocol.game_master.GameHandle.Builder builder = bnet.protocol.game_master.GameHandle.CreateBuilder();
                            if (this.result.hasGameHandle)
                            {
                                builder.MergeFrom(this.GameHandle);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameHandle = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasOpen = input.ReadBool(ref this.result.open_);
                            continue;
                        }
                        case 0x1a:
                        {
                            input.ReadMessageArray<bnet.protocol.game_master.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_master.Attribute.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasReplace = input.ReadBool(ref this.result.replace_);
                }
                return this;
            }

            public ChangeGameRequest.Builder MergeGameHandle(bnet.protocol.game_master.GameHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameHandle && (this.result.gameHandle_ != bnet.protocol.game_master.GameHandle.DefaultInstance))
                {
                    this.result.gameHandle_ = bnet.protocol.game_master.GameHandle.CreateBuilder(this.result.gameHandle_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameHandle_ = value;
                }
                this.result.hasGameHandle = true;
                return this;
            }

            private ChangeGameRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ChangeGameRequest result = this.result;
                    this.result = new ChangeGameRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ChangeGameRequest.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public ChangeGameRequest.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public ChangeGameRequest.Builder SetGameHandle(bnet.protocol.game_master.GameHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public ChangeGameRequest.Builder SetGameHandle(bnet.protocol.game_master.GameHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = builderForValue.Build();
                return this;
            }

            public ChangeGameRequest.Builder SetOpen(bool value)
            {
                this.PrepareBuilder();
                this.result.hasOpen = true;
                this.result.open_ = value;
                return this;
            }

            public ChangeGameRequest.Builder SetReplace(bool value)
            {
                this.PrepareBuilder();
                this.result.hasReplace = true;
                this.result.replace_ = value;
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_master.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override ChangeGameRequest DefaultInstanceForType
            {
                get
                {
                    return ChangeGameRequest.DefaultInstance;
                }
            }

            public bnet.protocol.game_master.GameHandle GameHandle
            {
                get
                {
                    return this.result.GameHandle;
                }
                set
                {
                    this.SetGameHandle(value);
                }
            }

            public bool HasGameHandle
            {
                get
                {
                    return this.result.hasGameHandle;
                }
            }

            public bool HasOpen
            {
                get
                {
                    return this.result.hasOpen;
                }
            }

            public bool HasReplace
            {
                get
                {
                    return this.result.hasReplace;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ChangeGameRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public bool Open
            {
                get
                {
                    return this.result.Open;
                }
                set
                {
                    this.SetOpen(value);
                }
            }

            public bool Replace
            {
                get
                {
                    return this.result.Replace;
                }
                set
                {
                    this.SetReplace(value);
                }
            }

            protected override ChangeGameRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

