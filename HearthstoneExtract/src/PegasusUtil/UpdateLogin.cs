namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class UpdateLogin : GeneratedMessageLite<UpdateLogin, Builder>
    {
        private static readonly string[] _updateLoginFieldNames = new string[0];
        private static readonly uint[] _updateLoginFieldTags = new uint[0];
        private static readonly UpdateLogin defaultInstance = new UpdateLogin().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static UpdateLogin()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private UpdateLogin()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UpdateLogin prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is UpdateLogin);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private UpdateLogin MakeReadOnly()
        {
            return this;
        }

        public static UpdateLogin ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UpdateLogin ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateLogin ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UpdateLogin ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UpdateLogin ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UpdateLogin ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UpdateLogin ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UpdateLogin ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateLogin ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateLogin ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _updateLoginFieldNames;
        }

        public static UpdateLogin DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UpdateLogin DefaultInstanceForType
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

        protected override UpdateLogin ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<UpdateLogin, UpdateLogin.Builder>
        {
            private UpdateLogin result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UpdateLogin.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UpdateLogin cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UpdateLogin BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UpdateLogin.Builder Clear()
            {
                this.result = UpdateLogin.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override UpdateLogin.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UpdateLogin.Builder(this.result);
                }
                return new UpdateLogin.Builder().MergeFrom(this.result);
            }

            public override UpdateLogin.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UpdateLogin.Builder MergeFrom(IMessageLite other)
            {
                if (other is UpdateLogin)
                {
                    return this.MergeFrom((UpdateLogin) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UpdateLogin.Builder MergeFrom(UpdateLogin other)
            {
                if (other != UpdateLogin.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override UpdateLogin.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UpdateLogin._updateLoginFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UpdateLogin._updateLoginFieldTags[index];
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

            private UpdateLogin PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UpdateLogin result = this.result;
                    this.result = new UpdateLogin();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override UpdateLogin DefaultInstanceForType
            {
                get
                {
                    return UpdateLogin.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UpdateLogin MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override UpdateLogin.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xcd,
                System = 0
            }
        }
    }
}

