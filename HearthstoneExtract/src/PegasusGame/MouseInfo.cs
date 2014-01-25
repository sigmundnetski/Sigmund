namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class MouseInfo : GeneratedMessageLite<MouseInfo, Builder>
    {
        private static readonly string[] _mouseInfoFieldNames = new string[] { "arrow_origin", "held_card", "over_card", "x", "y" };
        private static readonly uint[] _mouseInfoFieldTags = new uint[] { 8, 0x10, 0x18, 0x20, 40 };
        private int arrowOrigin_;
        public const int ArrowOriginFieldNumber = 1;
        private static readonly MouseInfo defaultInstance = new MouseInfo().MakeReadOnly();
        private bool hasArrowOrigin;
        private bool hasHeldCard;
        private bool hasOverCard;
        private bool hasX;
        private bool hasY;
        private int heldCard_;
        public const int HeldCardFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private int overCard_;
        public const int OverCardFieldNumber = 3;
        private int x_;
        public const int XFieldNumber = 4;
        private int y_;
        public const int YFieldNumber = 5;

        static MouseInfo()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private MouseInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MouseInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MouseInfo info = obj as MouseInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasArrowOrigin != info.hasArrowOrigin) || (this.hasArrowOrigin && !this.arrowOrigin_.Equals(info.arrowOrigin_)))
            {
                return false;
            }
            if ((this.hasHeldCard != info.hasHeldCard) || (this.hasHeldCard && !this.heldCard_.Equals(info.heldCard_)))
            {
                return false;
            }
            if ((this.hasOverCard != info.hasOverCard) || (this.hasOverCard && !this.overCard_.Equals(info.overCard_)))
            {
                return false;
            }
            if ((this.hasX != info.hasX) || (this.hasX && !this.x_.Equals(info.x_)))
            {
                return false;
            }
            return ((this.hasY == info.hasY) && (!this.hasY || this.y_.Equals(info.y_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasArrowOrigin)
            {
                hashCode ^= this.arrowOrigin_.GetHashCode();
            }
            if (this.hasHeldCard)
            {
                hashCode ^= this.heldCard_.GetHashCode();
            }
            if (this.hasOverCard)
            {
                hashCode ^= this.overCard_.GetHashCode();
            }
            if (this.hasX)
            {
                hashCode ^= this.x_.GetHashCode();
            }
            if (this.hasY)
            {
                hashCode ^= this.y_.GetHashCode();
            }
            return hashCode;
        }

        private MouseInfo MakeReadOnly()
        {
            return this;
        }

        public static MouseInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MouseInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MouseInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MouseInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MouseInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MouseInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MouseInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MouseInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MouseInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MouseInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MouseInfo, Builder>.PrintField("arrow_origin", this.hasArrowOrigin, this.arrowOrigin_, writer);
            GeneratedMessageLite<MouseInfo, Builder>.PrintField("held_card", this.hasHeldCard, this.heldCard_, writer);
            GeneratedMessageLite<MouseInfo, Builder>.PrintField("over_card", this.hasOverCard, this.overCard_, writer);
            GeneratedMessageLite<MouseInfo, Builder>.PrintField("x", this.hasX, this.x_, writer);
            GeneratedMessageLite<MouseInfo, Builder>.PrintField("y", this.hasY, this.y_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _mouseInfoFieldNames;
            if (this.hasArrowOrigin)
            {
                output.WriteInt32(1, strArray[0], this.ArrowOrigin);
            }
            if (this.hasHeldCard)
            {
                output.WriteInt32(2, strArray[1], this.HeldCard);
            }
            if (this.hasOverCard)
            {
                output.WriteInt32(3, strArray[2], this.OverCard);
            }
            if (this.hasX)
            {
                output.WriteInt32(4, strArray[3], this.X);
            }
            if (this.hasY)
            {
                output.WriteInt32(5, strArray[4], this.Y);
            }
        }

        public int ArrowOrigin
        {
            get
            {
                return this.arrowOrigin_;
            }
        }

        public static MouseInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MouseInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasArrowOrigin
        {
            get
            {
                return this.hasArrowOrigin;
            }
        }

        public bool HasHeldCard
        {
            get
            {
                return this.hasHeldCard;
            }
        }

        public bool HasOverCard
        {
            get
            {
                return this.hasOverCard;
            }
        }

        public bool HasX
        {
            get
            {
                return this.hasX;
            }
        }

        public bool HasY
        {
            get
            {
                return this.hasY;
            }
        }

        public int HeldCard
        {
            get
            {
                return this.heldCard_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasArrowOrigin)
                {
                    return false;
                }
                if (!this.hasHeldCard)
                {
                    return false;
                }
                if (!this.hasOverCard)
                {
                    return false;
                }
                if (!this.hasX)
                {
                    return false;
                }
                if (!this.hasY)
                {
                    return false;
                }
                return true;
            }
        }

        public int OverCard
        {
            get
            {
                return this.overCard_;
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
                    if (this.hasArrowOrigin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.ArrowOrigin);
                    }
                    if (this.hasHeldCard)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.HeldCard);
                    }
                    if (this.hasOverCard)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.OverCard);
                    }
                    if (this.hasX)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.X);
                    }
                    if (this.hasY)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.Y);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override MouseInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int X
        {
            get
            {
                return this.x_;
            }
        }

        public int Y
        {
            get
            {
                return this.y_;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<MouseInfo, MouseInfo.Builder>
        {
            private MouseInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MouseInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MouseInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override MouseInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MouseInfo.Builder Clear()
            {
                this.result = MouseInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MouseInfo.Builder ClearArrowOrigin()
            {
                this.PrepareBuilder();
                this.result.hasArrowOrigin = false;
                this.result.arrowOrigin_ = 0;
                return this;
            }

            public MouseInfo.Builder ClearHeldCard()
            {
                this.PrepareBuilder();
                this.result.hasHeldCard = false;
                this.result.heldCard_ = 0;
                return this;
            }

            public MouseInfo.Builder ClearOverCard()
            {
                this.PrepareBuilder();
                this.result.hasOverCard = false;
                this.result.overCard_ = 0;
                return this;
            }

            public MouseInfo.Builder ClearX()
            {
                this.PrepareBuilder();
                this.result.hasX = false;
                this.result.x_ = 0;
                return this;
            }

            public MouseInfo.Builder ClearY()
            {
                this.PrepareBuilder();
                this.result.hasY = false;
                this.result.y_ = 0;
                return this;
            }

            public override MouseInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MouseInfo.Builder(this.result);
                }
                return new MouseInfo.Builder().MergeFrom(this.result);
            }

            public override MouseInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MouseInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is MouseInfo)
                {
                    return this.MergeFrom((MouseInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MouseInfo.Builder MergeFrom(MouseInfo other)
            {
                if (other != MouseInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasArrowOrigin)
                    {
                        this.ArrowOrigin = other.ArrowOrigin;
                    }
                    if (other.HasHeldCard)
                    {
                        this.HeldCard = other.HeldCard;
                    }
                    if (other.HasOverCard)
                    {
                        this.OverCard = other.OverCard;
                    }
                    if (other.HasX)
                    {
                        this.X = other.X;
                    }
                    if (other.HasY)
                    {
                        this.Y = other.Y;
                    }
                }
                return this;
            }

            public override MouseInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MouseInfo._mouseInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MouseInfo._mouseInfoFieldTags[index];
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
                            this.result.hasArrowOrigin = input.ReadInt32(ref this.result.arrowOrigin_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasHeldCard = input.ReadInt32(ref this.result.heldCard_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasOverCard = input.ReadInt32(ref this.result.overCard_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasX = input.ReadInt32(ref this.result.x_);
                            continue;
                        }
                        case 40:
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
                    this.result.hasY = input.ReadInt32(ref this.result.y_);
                }
                return this;
            }

            private MouseInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MouseInfo result = this.result;
                    this.result = new MouseInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MouseInfo.Builder SetArrowOrigin(int value)
            {
                this.PrepareBuilder();
                this.result.hasArrowOrigin = true;
                this.result.arrowOrigin_ = value;
                return this;
            }

            public MouseInfo.Builder SetHeldCard(int value)
            {
                this.PrepareBuilder();
                this.result.hasHeldCard = true;
                this.result.heldCard_ = value;
                return this;
            }

            public MouseInfo.Builder SetOverCard(int value)
            {
                this.PrepareBuilder();
                this.result.hasOverCard = true;
                this.result.overCard_ = value;
                return this;
            }

            public MouseInfo.Builder SetX(int value)
            {
                this.PrepareBuilder();
                this.result.hasX = true;
                this.result.x_ = value;
                return this;
            }

            public MouseInfo.Builder SetY(int value)
            {
                this.PrepareBuilder();
                this.result.hasY = true;
                this.result.y_ = value;
                return this;
            }

            public int ArrowOrigin
            {
                get
                {
                    return this.result.ArrowOrigin;
                }
                set
                {
                    this.SetArrowOrigin(value);
                }
            }

            public override MouseInfo DefaultInstanceForType
            {
                get
                {
                    return MouseInfo.DefaultInstance;
                }
            }

            public bool HasArrowOrigin
            {
                get
                {
                    return this.result.hasArrowOrigin;
                }
            }

            public bool HasHeldCard
            {
                get
                {
                    return this.result.hasHeldCard;
                }
            }

            public bool HasOverCard
            {
                get
                {
                    return this.result.hasOverCard;
                }
            }

            public bool HasX
            {
                get
                {
                    return this.result.hasX;
                }
            }

            public bool HasY
            {
                get
                {
                    return this.result.hasY;
                }
            }

            public int HeldCard
            {
                get
                {
                    return this.result.HeldCard;
                }
                set
                {
                    this.SetHeldCard(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override MouseInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int OverCard
            {
                get
                {
                    return this.result.OverCard;
                }
                set
                {
                    this.SetOverCard(value);
                }
            }

            protected override MouseInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int X
            {
                get
                {
                    return this.result.X;
                }
                set
                {
                    this.SetX(value);
                }
            }

            public int Y
            {
                get
                {
                    return this.result.Y;
                }
                set
                {
                    this.SetY(value);
                }
            }
        }
    }
}

