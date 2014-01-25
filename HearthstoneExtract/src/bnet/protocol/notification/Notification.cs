namespace bnet.protocol.notification
{
    using bnet.protocol.notification.Proto;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Notification : GeneratedMessageLite<bnet.protocol.notification.Notification, Builder>
    {
        private static readonly string[] _notificationFieldNames = new string[] { "attribute", "sender_account_id", "sender_battle_tag", "sender_id", "target_account_id", "target_id", "type" };
        private static readonly uint[] _notificationFieldTags = new uint[] { 0x22, 0x2a, 0x3a, 10, 50, 0x12, 0x1a };
        private PopsicleList<bnet.protocol.notification.Attribute> attribute_ = new PopsicleList<bnet.protocol.notification.Attribute>();
        public const int AttributeFieldNumber = 4;
        private static readonly bnet.protocol.notification.Notification defaultInstance = new bnet.protocol.notification.Notification().MakeReadOnly();
        private bool hasSenderAccountId;
        private bool hasSenderBattleTag;
        private bool hasSenderId;
        private bool hasTargetAccountId;
        private bool hasTargetId;
        private bool hasType;
        private int memoizedSerializedSize = -1;
        private EntityId senderAccountId_;
        public const int SenderAccountIdFieldNumber = 5;
        private string senderBattleTag_ = string.Empty;
        public const int SenderBattleTagFieldNumber = 7;
        private EntityId senderId_;
        public const int SenderIdFieldNumber = 1;
        private EntityId targetAccountId_;
        public const int TargetAccountIdFieldNumber = 6;
        private EntityId targetId_;
        public const int TargetIdFieldNumber = 2;
        private string type_ = string.Empty;
        public const int TypeFieldNumber = 3;

        static Notification()
        {
            object.ReferenceEquals(bnet.protocol.notification.Proto.Notification.Descriptor, null);
        }

        private Notification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(bnet.protocol.notification.Notification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            bnet.protocol.notification.Notification notification = obj as bnet.protocol.notification.Notification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasSenderId != notification.hasSenderId) || (this.hasSenderId && !this.senderId_.Equals(notification.senderId_)))
            {
                return false;
            }
            if ((this.hasTargetId != notification.hasTargetId) || (this.hasTargetId && !this.targetId_.Equals(notification.targetId_)))
            {
                return false;
            }
            if ((this.hasType != notification.hasType) || (this.hasType && !this.type_.Equals(notification.type_)))
            {
                return false;
            }
            if (this.attribute_.Count != notification.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(notification.attribute_[i]))
                {
                    return false;
                }
            }
            if ((this.hasSenderAccountId != notification.hasSenderAccountId) || (this.hasSenderAccountId && !this.senderAccountId_.Equals(notification.senderAccountId_)))
            {
                return false;
            }
            if ((this.hasTargetAccountId != notification.hasTargetAccountId) || (this.hasTargetAccountId && !this.targetAccountId_.Equals(notification.targetAccountId_)))
            {
                return false;
            }
            return ((this.hasSenderBattleTag == notification.hasSenderBattleTag) && (!this.hasSenderBattleTag || this.senderBattleTag_.Equals(notification.senderBattleTag_)));
        }

        public bnet.protocol.notification.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasSenderId)
            {
                hashCode ^= this.senderId_.GetHashCode();
            }
            if (this.hasTargetId)
            {
                hashCode ^= this.targetId_.GetHashCode();
            }
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            IEnumerator<bnet.protocol.notification.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.notification.Attribute current = enumerator.Current;
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
            if (this.hasSenderAccountId)
            {
                hashCode ^= this.senderAccountId_.GetHashCode();
            }
            if (this.hasTargetAccountId)
            {
                hashCode ^= this.targetAccountId_.GetHashCode();
            }
            if (this.hasSenderBattleTag)
            {
                hashCode ^= this.senderBattleTag_.GetHashCode();
            }
            return hashCode;
        }

        private bnet.protocol.notification.Notification MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static bnet.protocol.notification.Notification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.notification.Notification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<bnet.protocol.notification.Notification, Builder>.PrintField("sender_id", this.hasSenderId, this.senderId_, writer);
            GeneratedMessageLite<bnet.protocol.notification.Notification, Builder>.PrintField("target_id", this.hasTargetId, this.targetId_, writer);
            GeneratedMessageLite<bnet.protocol.notification.Notification, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<bnet.protocol.notification.Notification, Builder>.PrintField<bnet.protocol.notification.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<bnet.protocol.notification.Notification, Builder>.PrintField("sender_account_id", this.hasSenderAccountId, this.senderAccountId_, writer);
            GeneratedMessageLite<bnet.protocol.notification.Notification, Builder>.PrintField("target_account_id", this.hasTargetAccountId, this.targetAccountId_, writer);
            GeneratedMessageLite<bnet.protocol.notification.Notification, Builder>.PrintField("sender_battle_tag", this.hasSenderBattleTag, this.senderBattleTag_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _notificationFieldNames;
            if (this.hasSenderId)
            {
                output.WriteMessage(1, strArray[3], this.SenderId);
            }
            if (this.hasTargetId)
            {
                output.WriteMessage(2, strArray[5], this.TargetId);
            }
            if (this.hasType)
            {
                output.WriteString(3, strArray[6], this.Type);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.notification.Attribute>(4, strArray[0], this.attribute_);
            }
            if (this.hasSenderAccountId)
            {
                output.WriteMessage(5, strArray[1], this.SenderAccountId);
            }
            if (this.hasTargetAccountId)
            {
                output.WriteMessage(6, strArray[4], this.TargetAccountId);
            }
            if (this.hasSenderBattleTag)
            {
                output.WriteString(7, strArray[2], this.SenderBattleTag);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.notification.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static bnet.protocol.notification.Notification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override bnet.protocol.notification.Notification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasSenderAccountId
        {
            get
            {
                return this.hasSenderAccountId;
            }
        }

        public bool HasSenderBattleTag
        {
            get
            {
                return this.hasSenderBattleTag;
            }
        }

        public bool HasSenderId
        {
            get
            {
                return this.hasSenderId;
            }
        }

        public bool HasTargetAccountId
        {
            get
            {
                return this.hasTargetAccountId;
            }
        }

        public bool HasTargetId
        {
            get
            {
                return this.hasTargetId;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasTargetId)
                {
                    return false;
                }
                if (!this.hasType)
                {
                    return false;
                }
                if (this.HasSenderId && !this.SenderId.IsInitialized)
                {
                    return false;
                }
                if (!this.TargetId.IsInitialized)
                {
                    return false;
                }
                IEnumerator<bnet.protocol.notification.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.notification.Attribute current = enumerator.Current;
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
                if (this.HasSenderAccountId && !this.SenderAccountId.IsInitialized)
                {
                    return false;
                }
                if (this.HasTargetAccountId && !this.TargetAccountId.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public EntityId SenderAccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.senderAccountId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public string SenderBattleTag
        {
            get
            {
                return this.senderBattleTag_;
            }
        }

        public EntityId SenderId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.senderId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
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
                    if (this.hasSenderId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.SenderId);
                    }
                    if (this.hasTargetId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.TargetId);
                    }
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Type);
                    }
                    IEnumerator<bnet.protocol.notification.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.notification.Attribute current = enumerator.Current;
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
                    if (this.hasSenderAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, this.SenderAccountId);
                    }
                    if (this.hasTargetAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(6, this.TargetAccountId);
                    }
                    if (this.hasSenderBattleTag)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(7, this.SenderBattleTag);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public EntityId TargetAccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.targetAccountId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public EntityId TargetId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.targetId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        protected override bnet.protocol.notification.Notification ThisMessage
        {
            get
            {
                return this;
            }
        }

        public string Type
        {
            get
            {
                return this.type_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<bnet.protocol.notification.Notification, bnet.protocol.notification.Notification.Builder>
        {
            private bnet.protocol.notification.Notification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = bnet.protocol.notification.Notification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(bnet.protocol.notification.Notification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public bnet.protocol.notification.Notification.Builder AddAttribute(bnet.protocol.notification.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public bnet.protocol.notification.Notification.Builder AddAttribute(bnet.protocol.notification.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public bnet.protocol.notification.Notification.Builder AddRangeAttribute(IEnumerable<bnet.protocol.notification.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override bnet.protocol.notification.Notification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override bnet.protocol.notification.Notification.Builder Clear()
            {
                this.result = bnet.protocol.notification.Notification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public bnet.protocol.notification.Notification.Builder ClearSenderAccountId()
            {
                this.PrepareBuilder();
                this.result.hasSenderAccountId = false;
                this.result.senderAccountId_ = null;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder ClearSenderBattleTag()
            {
                this.PrepareBuilder();
                this.result.hasSenderBattleTag = false;
                this.result.senderBattleTag_ = string.Empty;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder ClearSenderId()
            {
                this.PrepareBuilder();
                this.result.hasSenderId = false;
                this.result.senderId_ = null;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder ClearTargetAccountId()
            {
                this.PrepareBuilder();
                this.result.hasTargetAccountId = false;
                this.result.targetAccountId_ = null;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder ClearTargetId()
            {
                this.PrepareBuilder();
                this.result.hasTargetId = false;
                this.result.targetId_ = null;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = string.Empty;
                return this;
            }

            public override bnet.protocol.notification.Notification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new bnet.protocol.notification.Notification.Builder(this.result);
                }
                return new bnet.protocol.notification.Notification.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.notification.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override bnet.protocol.notification.Notification.Builder MergeFrom(bnet.protocol.notification.Notification other)
            {
                if (other != bnet.protocol.notification.Notification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasSenderId)
                    {
                        this.MergeSenderId(other.SenderId);
                    }
                    if (other.HasTargetId)
                    {
                        this.MergeTargetId(other.TargetId);
                    }
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.HasSenderAccountId)
                    {
                        this.MergeSenderAccountId(other.SenderAccountId);
                    }
                    if (other.HasTargetAccountId)
                    {
                        this.MergeTargetAccountId(other.TargetAccountId);
                    }
                    if (other.HasSenderBattleTag)
                    {
                        this.SenderBattleTag = other.SenderBattleTag;
                    }
                }
                return this;
            }

            public override bnet.protocol.notification.Notification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override bnet.protocol.notification.Notification.Builder MergeFrom(IMessageLite other)
            {
                if (other is bnet.protocol.notification.Notification)
                {
                    return this.MergeFrom((bnet.protocol.notification.Notification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override bnet.protocol.notification.Notification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(bnet.protocol.notification.Notification._notificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = bnet.protocol.notification.Notification._notificationFieldTags[index];
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
                            EntityId.Builder builder = EntityId.CreateBuilder();
                            if (this.result.hasSenderId)
                            {
                                builder.MergeFrom(this.SenderId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.SenderId = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            EntityId.Builder builder2 = EntityId.CreateBuilder();
                            if (this.result.hasTargetId)
                            {
                                builder2.MergeFrom(this.TargetId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.TargetId = builder2.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasType = input.ReadString(ref this.result.type_);
                            continue;
                        }
                        case 0x22:
                        {
                            input.ReadMessageArray<bnet.protocol.notification.Attribute>(num, str, this.result.attribute_, bnet.protocol.notification.Attribute.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x2a:
                        {
                            EntityId.Builder builder3 = EntityId.CreateBuilder();
                            if (this.result.hasSenderAccountId)
                            {
                                builder3.MergeFrom(this.SenderAccountId);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.SenderAccountId = builder3.BuildPartial();
                            continue;
                        }
                        case 50:
                        {
                            EntityId.Builder builder4 = EntityId.CreateBuilder();
                            if (this.result.hasTargetAccountId)
                            {
                                builder4.MergeFrom(this.TargetAccountId);
                            }
                            input.ReadMessage(builder4, extensionRegistry);
                            this.TargetAccountId = builder4.BuildPartial();
                            continue;
                        }
                        case 0x3a:
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
                    this.result.hasSenderBattleTag = input.ReadString(ref this.result.senderBattleTag_);
                }
                return this;
            }

            public bnet.protocol.notification.Notification.Builder MergeSenderAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasSenderAccountId && (this.result.senderAccountId_ != EntityId.DefaultInstance))
                {
                    this.result.senderAccountId_ = EntityId.CreateBuilder(this.result.senderAccountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.senderAccountId_ = value;
                }
                this.result.hasSenderAccountId = true;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder MergeSenderId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasSenderId && (this.result.senderId_ != EntityId.DefaultInstance))
                {
                    this.result.senderId_ = EntityId.CreateBuilder(this.result.senderId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.senderId_ = value;
                }
                this.result.hasSenderId = true;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder MergeTargetAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasTargetAccountId && (this.result.targetAccountId_ != EntityId.DefaultInstance))
                {
                    this.result.targetAccountId_ = EntityId.CreateBuilder(this.result.targetAccountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.targetAccountId_ = value;
                }
                this.result.hasTargetAccountId = true;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder MergeTargetId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasTargetId && (this.result.targetId_ != EntityId.DefaultInstance))
                {
                    this.result.targetId_ = EntityId.CreateBuilder(this.result.targetId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.targetId_ = value;
                }
                this.result.hasTargetId = true;
                return this;
            }

            private bnet.protocol.notification.Notification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    bnet.protocol.notification.Notification result = this.result;
                    this.result = new bnet.protocol.notification.Notification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public bnet.protocol.notification.Notification.Builder SetAttribute(int index, bnet.protocol.notification.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetAttribute(int index, bnet.protocol.notification.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetSenderAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSenderAccountId = true;
                this.result.senderAccountId_ = value;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetSenderAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasSenderAccountId = true;
                this.result.senderAccountId_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetSenderBattleTag(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSenderBattleTag = true;
                this.result.senderBattleTag_ = value;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetSenderId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSenderId = true;
                this.result.senderId_ = value;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetSenderId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasSenderId = true;
                this.result.senderId_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetTargetAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasTargetAccountId = true;
                this.result.targetAccountId_ = value;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetTargetAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasTargetAccountId = true;
                this.result.targetAccountId_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetTargetId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasTargetId = true;
                this.result.targetId_ = value;
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetTargetId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasTargetId = true;
                this.result.targetId_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.notification.Notification.Builder SetType(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.notification.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override bnet.protocol.notification.Notification DefaultInstanceForType
            {
                get
                {
                    return bnet.protocol.notification.Notification.DefaultInstance;
                }
            }

            public bool HasSenderAccountId
            {
                get
                {
                    return this.result.hasSenderAccountId;
                }
            }

            public bool HasSenderBattleTag
            {
                get
                {
                    return this.result.hasSenderBattleTag;
                }
            }

            public bool HasSenderId
            {
                get
                {
                    return this.result.hasSenderId;
                }
            }

            public bool HasTargetAccountId
            {
                get
                {
                    return this.result.hasTargetAccountId;
                }
            }

            public bool HasTargetId
            {
                get
                {
                    return this.result.hasTargetId;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override bnet.protocol.notification.Notification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public EntityId SenderAccountId
            {
                get
                {
                    return this.result.SenderAccountId;
                }
                set
                {
                    this.SetSenderAccountId(value);
                }
            }

            public string SenderBattleTag
            {
                get
                {
                    return this.result.SenderBattleTag;
                }
                set
                {
                    this.SetSenderBattleTag(value);
                }
            }

            public EntityId SenderId
            {
                get
                {
                    return this.result.SenderId;
                }
                set
                {
                    this.SetSenderId(value);
                }
            }

            public EntityId TargetAccountId
            {
                get
                {
                    return this.result.TargetAccountId;
                }
                set
                {
                    this.SetTargetAccountId(value);
                }
            }

            public EntityId TargetId
            {
                get
                {
                    return this.result.TargetId;
                }
                set
                {
                    this.SetTargetId(value);
                }
            }

            protected override bnet.protocol.notification.Notification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public string Type
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
    }
}

