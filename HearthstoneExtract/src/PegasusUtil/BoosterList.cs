namespace PegasusUtil
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
    public sealed class BoosterList : GeneratedMessageLite<BoosterList, Builder>
    {
        private static readonly string[] _boosterListFieldNames = new string[] { "list" };
        private static readonly uint[] _boosterListFieldTags = new uint[] { 10 };
        private static readonly BoosterList defaultInstance = new BoosterList().MakeReadOnly();
        private PopsicleList<BoosterInfo> list_ = new PopsicleList<BoosterInfo>();
        public const int ListFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static BoosterList()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private BoosterList()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BoosterList prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BoosterList list = obj as BoosterList;
            if (list == null)
            {
                return false;
            }
            if (this.list_.Count != list.list_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.list_.Count; i++)
            {
                if (!this.list_[i].Equals(list.list_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<BoosterInfo> enumerator = this.list_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    BoosterInfo current = enumerator.Current;
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

        public BoosterInfo GetList(int index)
        {
            return this.list_[index];
        }

        private BoosterList MakeReadOnly()
        {
            this.list_.MakeReadOnly();
            return this;
        }

        public static BoosterList ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BoosterList ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterList ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoosterList ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoosterList ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoosterList ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoosterList ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BoosterList ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterList ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterList ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BoosterList, Builder>.PrintField<BoosterInfo>("list", this.list_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _boosterListFieldNames;
            if (this.list_.Count > 0)
            {
                output.WriteMessageArray<BoosterInfo>(1, strArray[0], this.list_);
            }
        }

        public static BoosterList DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BoosterList DefaultInstanceForType
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
                IEnumerator<BoosterInfo> enumerator = this.ListList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        BoosterInfo current = enumerator.Current;
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

        public int ListCount
        {
            get
            {
                return this.list_.Count;
            }
        }

        public IList<BoosterInfo> ListList
        {
            get
            {
                return this.list_;
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
                    IEnumerator<BoosterInfo> enumerator = this.ListList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            BoosterInfo current = enumerator.Current;
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

        protected override BoosterList ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<BoosterList, BoosterList.Builder>
        {
            private BoosterList result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BoosterList.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BoosterList cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public BoosterList.Builder AddList(BoosterInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_.Add(value);
                return this;
            }

            public BoosterList.Builder AddList(BoosterInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_.Add(builderForValue.Build());
                return this;
            }

            public BoosterList.Builder AddRangeList(IEnumerable<BoosterInfo> values)
            {
                this.PrepareBuilder();
                this.result.list_.Add(values);
                return this;
            }

            public override BoosterList BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BoosterList.Builder Clear()
            {
                this.result = BoosterList.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BoosterList.Builder ClearList()
            {
                this.PrepareBuilder();
                this.result.list_.Clear();
                return this;
            }

            public override BoosterList.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BoosterList.Builder(this.result);
                }
                return new BoosterList.Builder().MergeFrom(this.result);
            }

            public BoosterInfo GetList(int index)
            {
                return this.result.GetList(index);
            }

            public override BoosterList.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BoosterList.Builder MergeFrom(IMessageLite other)
            {
                if (other is BoosterList)
                {
                    return this.MergeFrom((BoosterList) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BoosterList.Builder MergeFrom(BoosterList other)
            {
                if (other != BoosterList.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.list_.Count != 0)
                    {
                        this.result.list_.Add(other.list_);
                    }
                }
                return this;
            }

            public override BoosterList.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BoosterList._boosterListFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BoosterList._boosterListFieldTags[index];
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
                    input.ReadMessageArray<BoosterInfo>(num, str, this.result.list_, BoosterInfo.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private BoosterList PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BoosterList result = this.result;
                    this.result = new BoosterList();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BoosterList.Builder SetList(int index, BoosterInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_[index] = value;
                return this;
            }

            public BoosterList.Builder SetList(int index, BoosterInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_[index] = builderForValue.Build();
                return this;
            }

            public override BoosterList DefaultInstanceForType
            {
                get
                {
                    return BoosterList.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int ListCount
            {
                get
                {
                    return this.result.ListCount;
                }
            }

            public IPopsicleList<BoosterInfo> ListList
            {
                get
                {
                    return this.PrepareBuilder().list_;
                }
            }

            protected override BoosterList MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BoosterList.Builder ThisBuilder
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
                ID = 0xe0
            }
        }
    }
}

