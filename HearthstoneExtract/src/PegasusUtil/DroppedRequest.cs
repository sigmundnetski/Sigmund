namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DroppedRequest : GeneratedMessageLite<DroppedRequest, Builder>
    {
        private static readonly string[] _droppedRequestFieldNames = new string[0];
        private static readonly uint[] _droppedRequestFieldTags = new uint[0];
        private static readonly DroppedRequest defaultInstance = new DroppedRequest().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DroppedRequest()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DroppedRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DroppedRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is DroppedRequest);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private DroppedRequest MakeReadOnly()
        {
            return this;
        }

        public static DroppedRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DroppedRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DroppedRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DroppedRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DroppedRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DroppedRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DroppedRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DroppedRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DroppedRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DroppedRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _droppedRequestFieldNames;
        }

        public static DroppedRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DroppedRequest DefaultInstanceForType
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DroppedRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DroppedRequest, DroppedRequest.Builder>
        {
            private DroppedRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DroppedRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DroppedRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DroppedRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DroppedRequest.Builder Clear()
            {
                this.result = DroppedRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override DroppedRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DroppedRequest.Builder(this.result);
                }
                return new DroppedRequest.Builder().MergeFrom(this.result);
            }

            public override DroppedRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DroppedRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is DroppedRequest)
                {
                    return this.MergeFrom((DroppedRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DroppedRequest.Builder MergeFrom(DroppedRequest other)
            {
                if (other != DroppedRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override DroppedRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DroppedRequest._droppedRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DroppedRequest._droppedRequestFieldTags[index];
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
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private DroppedRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DroppedRequest result = this.result;
                    this.result = new DroppedRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override DroppedRequest DefaultInstanceForType
            {
                get
                {
                    return DroppedRequest.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DroppedRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DroppedRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID
            }
        }
    }
}

