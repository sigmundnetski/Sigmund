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
    public sealed class GameAccountBlobList : GeneratedMessageLite<GameAccountBlobList, Builder>
    {
        private static readonly string[] _gameAccountBlobListFieldNames = new string[] { "blob" };
        private static readonly uint[] _gameAccountBlobListFieldTags = new uint[] { 10 };
        private PopsicleList<GameAccountBlob> blob_ = new PopsicleList<GameAccountBlob>();
        public const int BlobFieldNumber = 1;
        private static readonly GameAccountBlobList defaultInstance = new GameAccountBlobList().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static GameAccountBlobList()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private GameAccountBlobList()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameAccountBlobList prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameAccountBlobList list = obj as GameAccountBlobList;
            if (list == null)
            {
                return false;
            }
            if (this.blob_.Count != list.blob_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.blob_.Count; i++)
            {
                if (!this.blob_[i].Equals(list.blob_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public GameAccountBlob GetBlob(int index)
        {
            return this.blob_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<GameAccountBlob> enumerator = this.blob_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    GameAccountBlob current = enumerator.Current;
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

        private GameAccountBlobList MakeReadOnly()
        {
            this.blob_.MakeReadOnly();
            return this;
        }

        public static GameAccountBlobList ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameAccountBlobList ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountBlobList ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountBlobList ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountBlobList ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountBlobList ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountBlobList ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameAccountBlobList ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountBlobList ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountBlobList ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameAccountBlobList, Builder>.PrintField<GameAccountBlob>("blob", this.blob_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameAccountBlobListFieldNames;
            if (this.blob_.Count > 0)
            {
                output.WriteMessageArray<GameAccountBlob>(1, strArray[0], this.blob_);
            }
        }

        public int BlobCount
        {
            get
            {
                return this.blob_.Count;
            }
        }

        public IList<GameAccountBlob> BlobList
        {
            get
            {
                return this.blob_;
            }
        }

        public static GameAccountBlobList DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameAccountBlobList DefaultInstanceForType
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
                IEnumerator<GameAccountBlob> enumerator = this.BlobList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        GameAccountBlob current = enumerator.Current;
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
                    IEnumerator<GameAccountBlob> enumerator = this.BlobList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            GameAccountBlob current = enumerator.Current;
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

        protected override GameAccountBlobList ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GameAccountBlobList, GameAccountBlobList.Builder>
        {
            private GameAccountBlobList result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameAccountBlobList.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameAccountBlobList cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GameAccountBlobList.Builder AddBlob(GameAccountBlob value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.blob_.Add(value);
                return this;
            }

            public GameAccountBlobList.Builder AddBlob(GameAccountBlob.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.blob_.Add(builderForValue.Build());
                return this;
            }

            public GameAccountBlobList.Builder AddRangeBlob(IEnumerable<GameAccountBlob> values)
            {
                this.PrepareBuilder();
                this.result.blob_.Add(values);
                return this;
            }

            public override GameAccountBlobList BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameAccountBlobList.Builder Clear()
            {
                this.result = GameAccountBlobList.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameAccountBlobList.Builder ClearBlob()
            {
                this.PrepareBuilder();
                this.result.blob_.Clear();
                return this;
            }

            public override GameAccountBlobList.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameAccountBlobList.Builder(this.result);
                }
                return new GameAccountBlobList.Builder().MergeFrom(this.result);
            }

            public GameAccountBlob GetBlob(int index)
            {
                return this.result.GetBlob(index);
            }

            public override GameAccountBlobList.Builder MergeFrom(GameAccountBlobList other)
            {
                if (other != GameAccountBlobList.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.blob_.Count != 0)
                    {
                        this.result.blob_.Add(other.blob_);
                    }
                }
                return this;
            }

            public override GameAccountBlobList.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameAccountBlobList.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameAccountBlobList)
                {
                    return this.MergeFrom((GameAccountBlobList) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameAccountBlobList.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameAccountBlobList._gameAccountBlobListFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameAccountBlobList._gameAccountBlobListFieldTags[index];
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
                    input.ReadMessageArray<GameAccountBlob>(num, str, this.result.blob_, GameAccountBlob.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private GameAccountBlobList PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameAccountBlobList result = this.result;
                    this.result = new GameAccountBlobList();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameAccountBlobList.Builder SetBlob(int index, GameAccountBlob value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.blob_[index] = value;
                return this;
            }

            public GameAccountBlobList.Builder SetBlob(int index, GameAccountBlob.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.blob_[index] = builderForValue.Build();
                return this;
            }

            public int BlobCount
            {
                get
                {
                    return this.result.BlobCount;
                }
            }

            public IPopsicleList<GameAccountBlob> BlobList
            {
                get
                {
                    return this.PrepareBuilder().blob_;
                }
            }

            public override GameAccountBlobList DefaultInstanceForType
            {
                get
                {
                    return GameAccountBlobList.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameAccountBlobList MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameAccountBlobList.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

