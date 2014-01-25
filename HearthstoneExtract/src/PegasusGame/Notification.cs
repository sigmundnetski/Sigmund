namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class Notification : GeneratedMessageLite<Notification, Builder>
    {
        private static readonly string[] _notificationFieldNames = new string[] { "type" };
        private static readonly uint[] _notificationFieldTags = new uint[] { 8 };
        private static readonly Notification defaultInstance = new Notification().MakeReadOnly();
        private bool hasType;
        private int memoizedSerializedSize = -1;
        private PegasusGame.Notification.Types.Type type_ = PegasusGame.Notification.Types.Type.IN_HAND_CARD_CAP;
        public const int TypeFieldNumber = 1;

        static Notification()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private Notification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Notification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Notification notification = obj as Notification;
            if (notification == null)
            {
                return false;
            }
            return ((this.hasType == notification.hasType) && (!this.hasType || this.type_.Equals(notification.type_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            return hashCode;
        }

        private Notification MakeReadOnly()
        {
            return this;
        }

        public static Notification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Notification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Notification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Notification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Notification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Notification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Notification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Notification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Notification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Notification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Notification, Builder>.PrintField("type", this.hasType, this.type_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _notificationFieldNames;
            if (this.hasType)
            {
                output.WriteEnum(1, strArray[0], (int) this.Type, this.Type);
            }
        }

        public static Notification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Notification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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
                if (!this.hasType)
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
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Type);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Notification ThisMessage
        {
            get
            {
                return this;
            }
        }

        public PegasusGame.Notification.Types.Type Type
        {
            get
            {
                return this.type_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<Notification, Notification.Builder>
        {
            private Notification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Notification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Notification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Notification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Notification.Builder Clear()
            {
                this.result = Notification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Notification.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = PegasusGame.Notification.Types.Type.IN_HAND_CARD_CAP;
                return this;
            }

            public override Notification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Notification.Builder(this.result);
                }
                return new Notification.Builder().MergeFrom(this.result);
            }

            public override Notification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Notification.Builder MergeFrom(IMessageLite other)
            {
                if (other is Notification)
                {
                    return this.MergeFrom((Notification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Notification.Builder MergeFrom(Notification other)
            {
                if (other != Notification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                }
                return this;
            }

            public override Notification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Notification._notificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Notification._notificationFieldTags[index];
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
                    if (input.ReadEnum<PegasusGame.Notification.Types.Type>(ref this.result.type_, out obj2))
                    {
                        this.result.hasType = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private Notification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Notification result = this.result;
                    this.result = new Notification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Notification.Builder SetType(PegasusGame.Notification.Types.Type value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public override Notification DefaultInstanceForType
            {
                get
                {
                    return Notification.DefaultInstance;
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

            protected override Notification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Notification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public PegasusGame.Notification.Types.Type Type
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x15
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Type
            {
                IN_HAND_CARD_CAP = 1,
                MANA_CAP = 2
            }
        }
    }
}

