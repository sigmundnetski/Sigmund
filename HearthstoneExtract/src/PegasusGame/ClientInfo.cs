namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ClientInfo : GeneratedMessageLite<ClientInfo, Builder>
    {
        private static readonly string[] _clientInfoFieldNames = new string[] { "card_back", "pieces" };
        private static readonly uint[] _clientInfoFieldTags = new uint[] { 0x10, 10 };
        private int cardBack_;
        public const int CardBackFieldNumber = 2;
        private static readonly ClientInfo defaultInstance = new ClientInfo().MakeReadOnly();
        private bool hasCardBack;
        private int memoizedSerializedSize = -1;
        private PopsicleList<int> pieces_ = new PopsicleList<int>();
        public const int PiecesFieldNumber = 1;
        private int piecesMemoizedSerializedSize;

        static ClientInfo()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private ClientInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ClientInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ClientInfo info = obj as ClientInfo;
            if (info == null)
            {
                return false;
            }
            if (this.pieces_.Count != info.pieces_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.pieces_.Count; i++)
            {
                int num2 = this.pieces_[i];
                if (!num2.Equals(info.pieces_[i]))
                {
                    return false;
                }
            }
            return ((this.hasCardBack == info.hasCardBack) && (!this.hasCardBack || this.cardBack_.Equals(info.cardBack_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<int> enumerator = this.pieces_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
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
            if (this.hasCardBack)
            {
                hashCode ^= this.cardBack_.GetHashCode();
            }
            return hashCode;
        }

        public int GetPieces(int index)
        {
            return this.pieces_[index];
        }

        private ClientInfo MakeReadOnly()
        {
            this.pieces_.MakeReadOnly();
            return this;
        }

        public static ClientInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ClientInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ClientInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ClientInfo, Builder>.PrintField<int>("pieces", this.pieces_, writer);
            GeneratedMessageLite<ClientInfo, Builder>.PrintField("card_back", this.hasCardBack, this.cardBack_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _clientInfoFieldNames;
            if (this.pieces_.Count > 0)
            {
                output.WritePackedInt32Array(1, strArray[1], this.piecesMemoizedSerializedSize, this.pieces_);
            }
            if (this.hasCardBack)
            {
                output.WriteInt32(2, strArray[0], this.CardBack);
            }
        }

        public int CardBack
        {
            get
            {
                return this.cardBack_;
            }
        }

        public static ClientInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ClientInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCardBack
        {
            get
            {
                return this.hasCardBack;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCardBack)
                {
                    return false;
                }
                return true;
            }
        }

        public int PiecesCount
        {
            get
            {
                return this.pieces_.Count;
            }
        }

        public IList<int> PiecesList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.pieces_);
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
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.PiecesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            int current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeInt32SizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.pieces_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.piecesMemoizedSerializedSize = num2;
                    if (this.hasCardBack)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.CardBack);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ClientInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ClientInfo, ClientInfo.Builder>
        {
            private ClientInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ClientInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ClientInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ClientInfo.Builder AddPieces(int value)
            {
                this.PrepareBuilder();
                this.result.pieces_.Add(value);
                return this;
            }

            public ClientInfo.Builder AddRangePieces(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.pieces_.Add(values);
                return this;
            }

            public override ClientInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ClientInfo.Builder Clear()
            {
                this.result = ClientInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ClientInfo.Builder ClearCardBack()
            {
                this.PrepareBuilder();
                this.result.hasCardBack = false;
                this.result.cardBack_ = 0;
                return this;
            }

            public ClientInfo.Builder ClearPieces()
            {
                this.PrepareBuilder();
                this.result.pieces_.Clear();
                return this;
            }

            public override ClientInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ClientInfo.Builder(this.result);
                }
                return new ClientInfo.Builder().MergeFrom(this.result);
            }

            public int GetPieces(int index)
            {
                return this.result.GetPieces(index);
            }

            public override ClientInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ClientInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is ClientInfo)
                {
                    return this.MergeFrom((ClientInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ClientInfo.Builder MergeFrom(ClientInfo other)
            {
                if (other != ClientInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.pieces_.Count != 0)
                    {
                        this.result.pieces_.Add(other.pieces_);
                    }
                    if (other.HasCardBack)
                    {
                        this.CardBack = other.CardBack;
                    }
                }
                return this;
            }

            public override ClientInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ClientInfo._clientInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ClientInfo._clientInfoFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 8:
                        case 10:
                        {
                            input.ReadInt32Array(num, str, this.result.pieces_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 0x10:
                            goto Label_00B2;

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
                Label_00B2:
                    this.result.hasCardBack = input.ReadInt32(ref this.result.cardBack_);
                }
                return this;
            }

            private ClientInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ClientInfo result = this.result;
                    this.result = new ClientInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ClientInfo.Builder SetCardBack(int value)
            {
                this.PrepareBuilder();
                this.result.hasCardBack = true;
                this.result.cardBack_ = value;
                return this;
            }

            public ClientInfo.Builder SetPieces(int index, int value)
            {
                this.PrepareBuilder();
                this.result.pieces_[index] = value;
                return this;
            }

            public int CardBack
            {
                get
                {
                    return this.result.CardBack;
                }
                set
                {
                    this.SetCardBack(value);
                }
            }

            public override ClientInfo DefaultInstanceForType
            {
                get
                {
                    return ClientInfo.DefaultInstance;
                }
            }

            public bool HasCardBack
            {
                get
                {
                    return this.result.hasCardBack;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ClientInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PiecesCount
            {
                get
                {
                    return this.result.PiecesCount;
                }
            }

            public IPopsicleList<int> PiecesList
            {
                get
                {
                    return this.PrepareBuilder().pieces_;
                }
            }

            protected override ClientInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

