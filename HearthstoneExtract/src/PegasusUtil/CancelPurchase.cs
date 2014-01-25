namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class CancelPurchase : GeneratedMessageLite<CancelPurchase, Builder>
    {
        private static readonly string[] _cancelPurchaseFieldNames = new string[] { "is_auto_cancel" };
        private static readonly uint[] _cancelPurchaseFieldTags = new uint[] { 8 };
        private static readonly CancelPurchase defaultInstance = new CancelPurchase().MakeReadOnly();
        private bool hasIsAutoCancel;
        private bool isAutoCancel_;
        public const int IsAutoCancelFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static CancelPurchase()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CancelPurchase()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CancelPurchase prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CancelPurchase purchase = obj as CancelPurchase;
            if (purchase == null)
            {
                return false;
            }
            return ((this.hasIsAutoCancel == purchase.hasIsAutoCancel) && (!this.hasIsAutoCancel || this.isAutoCancel_.Equals(purchase.isAutoCancel_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasIsAutoCancel)
            {
                hashCode ^= this.isAutoCancel_.GetHashCode();
            }
            return hashCode;
        }

        private CancelPurchase MakeReadOnly()
        {
            return this;
        }

        public static CancelPurchase ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CancelPurchase ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelPurchase ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelPurchase ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelPurchase ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelPurchase ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelPurchase ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CancelPurchase ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelPurchase ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelPurchase ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CancelPurchase, Builder>.PrintField("is_auto_cancel", this.hasIsAutoCancel, this.isAutoCancel_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cancelPurchaseFieldNames;
            if (this.hasIsAutoCancel)
            {
                output.WriteBool(1, strArray[0], this.IsAutoCancel);
            }
        }

        public static CancelPurchase DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CancelPurchase DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasIsAutoCancel
        {
            get
            {
                return this.hasIsAutoCancel;
            }
        }

        public bool IsAutoCancel
        {
            get
            {
                return this.isAutoCancel_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasIsAutoCancel)
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
                    if (this.hasIsAutoCancel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(1, this.IsAutoCancel);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CancelPurchase ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CancelPurchase, CancelPurchase.Builder>
        {
            private CancelPurchase result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CancelPurchase.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CancelPurchase cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CancelPurchase BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CancelPurchase.Builder Clear()
            {
                this.result = CancelPurchase.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CancelPurchase.Builder ClearIsAutoCancel()
            {
                this.PrepareBuilder();
                this.result.hasIsAutoCancel = false;
                this.result.isAutoCancel_ = false;
                return this;
            }

            public override CancelPurchase.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CancelPurchase.Builder(this.result);
                }
                return new CancelPurchase.Builder().MergeFrom(this.result);
            }

            public override CancelPurchase.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CancelPurchase.Builder MergeFrom(IMessageLite other)
            {
                if (other is CancelPurchase)
                {
                    return this.MergeFrom((CancelPurchase) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CancelPurchase.Builder MergeFrom(CancelPurchase other)
            {
                if (other != CancelPurchase.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasIsAutoCancel)
                    {
                        this.IsAutoCancel = other.IsAutoCancel;
                    }
                }
                return this;
            }

            public override CancelPurchase.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CancelPurchase._cancelPurchaseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CancelPurchase._cancelPurchaseFieldTags[index];
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
                    this.result.hasIsAutoCancel = input.ReadBool(ref this.result.isAutoCancel_);
                }
                return this;
            }

            private CancelPurchase PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CancelPurchase result = this.result;
                    this.result = new CancelPurchase();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CancelPurchase.Builder SetIsAutoCancel(bool value)
            {
                this.PrepareBuilder();
                this.result.hasIsAutoCancel = true;
                this.result.isAutoCancel_ = value;
                return this;
            }

            public override CancelPurchase DefaultInstanceForType
            {
                get
                {
                    return CancelPurchase.DefaultInstance;
                }
            }

            public bool HasIsAutoCancel
            {
                get
                {
                    return this.result.hasIsAutoCancel;
                }
            }

            public bool IsAutoCancel
            {
                get
                {
                    return this.result.IsAutoCancel;
                }
                set
                {
                    this.SetIsAutoCancel(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CancelPurchase MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override CancelPurchase.Builder ThisBuilder
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
                ID = 0x112,
                System = 1
            }
        }
    }
}

