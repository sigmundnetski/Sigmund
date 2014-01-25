namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class Wallets : GeneratedMessageLite<Wallets, Builder>
    {
        private static readonly string[] _walletsFieldNames = new string[] { "wallets" };
        private static readonly uint[] _walletsFieldTags = new uint[] { 10 };
        private static readonly Wallets defaultInstance = new Wallets().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<Wallet> wallets_ = new PopsicleList<Wallet>();
        public const int Wallets_FieldNumber = 1;

        static Wallets()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private Wallets()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Wallets prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Wallets wallets = obj as Wallets;
            if (wallets == null)
            {
                return false;
            }
            if (this.wallets_.Count != wallets.wallets_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.wallets_.Count; i++)
            {
                if (!this.wallets_[i].Equals(wallets.wallets_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Wallet> enumerator = this.wallets_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Wallet current = enumerator.Current;
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
            return hashCode;
        }

        public Wallet GetWallets_(int index)
        {
            return this.wallets_[index];
        }

        private Wallets MakeReadOnly()
        {
            this.wallets_.MakeReadOnly();
            return this;
        }

        public static Wallets ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Wallets ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Wallets ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Wallets ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Wallets ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Wallets ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Wallets ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Wallets ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Wallets ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Wallets ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Wallets, Builder>.PrintField<Wallet>("wallets", this.wallets_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _walletsFieldNames;
            if (this.wallets_.Count > 0)
            {
                output.WriteMessageArray<Wallet>(1, strArray[0], this.wallets_);
            }
        }

        public static Wallets DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Wallets DefaultInstanceForType
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
                IEnumerator<Wallet> enumerator = this.Wallets_List.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Wallet current = enumerator.Current;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<Wallet> enumerator = this.Wallets_List.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Wallet current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Wallets ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Wallets_Count
        {
            get
            {
                return this.wallets_.Count;
            }
        }

        public IList<Wallet> Wallets_List
        {
            get
            {
                return this.wallets_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<Wallets, Wallets.Builder>
        {
            private Wallets result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Wallets.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Wallets cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public Wallets.Builder AddRangeWallets_(IEnumerable<Wallet> values)
            {
                this.PrepareBuilder();
                this.result.wallets_.Add(values);
                return this;
            }

            public Wallets.Builder AddWallets_(Wallet value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.wallets_.Add(value);
                return this;
            }

            public Wallets.Builder AddWallets_(Wallet.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.wallets_.Add(builderForValue.Build());
                return this;
            }

            public override Wallets BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Wallets.Builder Clear()
            {
                this.result = Wallets.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Wallets.Builder ClearWallets_()
            {
                this.PrepareBuilder();
                this.result.wallets_.Clear();
                return this;
            }

            public override Wallets.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Wallets.Builder(this.result);
                }
                return new Wallets.Builder().MergeFrom(this.result);
            }

            public Wallet GetWallets_(int index)
            {
                return this.result.GetWallets_(index);
            }

            public override Wallets.Builder MergeFrom(Wallets other)
            {
                if (other != Wallets.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.wallets_.Count != 0)
                    {
                        this.result.wallets_.Add(other.wallets_);
                    }
                }
                return this;
            }

            public override Wallets.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Wallets.Builder MergeFrom(IMessageLite other)
            {
                if (other is Wallets)
                {
                    return this.MergeFrom((Wallets) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Wallets.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Wallets._walletsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Wallets._walletsFieldTags[index];
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
                    input.ReadMessageArray<Wallet>(num, str, this.result.wallets_, Wallet.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private Wallets PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Wallets result = this.result;
                    this.result = new Wallets();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Wallets.Builder SetWallets_(int index, Wallet value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.wallets_[index] = value;
                return this;
            }

            public Wallets.Builder SetWallets_(int index, Wallet.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.wallets_[index] = builderForValue.Build();
                return this;
            }

            public override Wallets DefaultInstanceForType
            {
                get
                {
                    return Wallets.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Wallets MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Wallets.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Wallets_Count
            {
                get
                {
                    return this.result.Wallets_Count;
                }
            }

            public IPopsicleList<Wallet> Wallets_List
            {
                get
                {
                    return this.PrepareBuilder().wallets_;
                }
            }
        }
    }
}

