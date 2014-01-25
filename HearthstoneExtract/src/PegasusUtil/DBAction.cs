namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DBAction : GeneratedMessageLite<DBAction, Builder>
    {
        private static readonly string[] _dBActionFieldNames = new string[] { "action", "meta_data", "result" };
        private static readonly uint[] _dBActionFieldTags = new uint[] { 8, 0x18, 0x10 };
        private PegasusUtil.DBAction.Types.Action action_;
        public const int ActionFieldNumber = 1;
        private static readonly DBAction defaultInstance = new DBAction().MakeReadOnly();
        private bool hasAction;
        private bool hasMetaData;
        private bool hasResult;
        private int memoizedSerializedSize = -1;
        private long metaData_;
        public const int MetaDataFieldNumber = 3;
        private PegasusUtil.DBAction.Types.Result result_ = PegasusUtil.DBAction.Types.Result.E_SQL_EX;
        public const int ResultFieldNumber = 2;

        static DBAction()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DBAction()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DBAction prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DBAction action = obj as DBAction;
            if (action == null)
            {
                return false;
            }
            if ((this.hasAction != action.hasAction) || (this.hasAction && !this.action_.Equals(action.action_)))
            {
                return false;
            }
            if ((this.hasResult != action.hasResult) || (this.hasResult && !this.result_.Equals(action.result_)))
            {
                return false;
            }
            return ((this.hasMetaData == action.hasMetaData) && (!this.hasMetaData || this.metaData_.Equals(action.metaData_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAction)
            {
                hashCode ^= this.action_.GetHashCode();
            }
            if (this.hasResult)
            {
                hashCode ^= this.result_.GetHashCode();
            }
            if (this.hasMetaData)
            {
                hashCode ^= this.metaData_.GetHashCode();
            }
            return hashCode;
        }

        private DBAction MakeReadOnly()
        {
            return this;
        }

        public static DBAction ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DBAction ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DBAction ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DBAction ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DBAction ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DBAction ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DBAction ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DBAction ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DBAction ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DBAction ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DBAction, Builder>.PrintField("action", this.hasAction, this.action_, writer);
            GeneratedMessageLite<DBAction, Builder>.PrintField("result", this.hasResult, this.result_, writer);
            GeneratedMessageLite<DBAction, Builder>.PrintField("meta_data", this.hasMetaData, this.metaData_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _dBActionFieldNames;
            if (this.hasAction)
            {
                output.WriteEnum(1, strArray[0], (int) this.Action, this.Action);
            }
            if (this.hasResult)
            {
                output.WriteEnum(2, strArray[2], (int) this.Result, this.Result);
            }
            if (this.hasMetaData)
            {
                output.WriteInt64(3, strArray[1], this.MetaData);
            }
        }

        public PegasusUtil.DBAction.Types.Action Action
        {
            get
            {
                return this.action_;
            }
        }

        public static DBAction DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DBAction DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAction
        {
            get
            {
                return this.hasAction;
            }
        }

        public bool HasMetaData
        {
            get
            {
                return this.hasMetaData;
            }
        }

        public bool HasResult
        {
            get
            {
                return this.hasResult;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAction)
                {
                    return false;
                }
                if (!this.hasResult)
                {
                    return false;
                }
                return true;
            }
        }

        public long MetaData
        {
            get
            {
                return this.metaData_;
            }
        }

        public PegasusUtil.DBAction.Types.Result Result
        {
            get
            {
                return this.result_;
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
                    if (this.hasAction)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Action);
                    }
                    if (this.hasResult)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(2, (int) this.Result);
                    }
                    if (this.hasMetaData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(3, this.MetaData);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DBAction ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DBAction, DBAction.Builder>
        {
            private DBAction result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DBAction.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DBAction cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DBAction BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DBAction.Builder Clear()
            {
                this.result = DBAction.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DBAction.Builder ClearAction()
            {
                this.PrepareBuilder();
                this.result.hasAction = false;
                this.result.action_ = PegasusUtil.DBAction.Types.Action.A_UNKNOWN;
                return this;
            }

            public DBAction.Builder ClearMetaData()
            {
                this.PrepareBuilder();
                this.result.hasMetaData = false;
                this.result.metaData_ = 0L;
                return this;
            }

            public DBAction.Builder ClearResult()
            {
                this.PrepareBuilder();
                this.result.hasResult = false;
                this.result.result_ = PegasusUtil.DBAction.Types.Result.E_SQL_EX;
                return this;
            }

            public override DBAction.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DBAction.Builder(this.result);
                }
                return new DBAction.Builder().MergeFrom(this.result);
            }

            public override DBAction.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DBAction.Builder MergeFrom(IMessageLite other)
            {
                if (other is DBAction)
                {
                    return this.MergeFrom((DBAction) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DBAction.Builder MergeFrom(DBAction other)
            {
                if (other != DBAction.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAction)
                    {
                        this.Action = other.Action;
                    }
                    if (other.HasResult)
                    {
                        this.Result = other.Result;
                    }
                    if (other.HasMetaData)
                    {
                        this.MetaData = other.MetaData;
                    }
                }
                return this;
            }

            public override DBAction.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DBAction._dBActionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DBAction._dBActionFieldTags[index];
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
                            object obj2;
                            if (input.ReadEnum<PegasusUtil.DBAction.Types.Action>(ref this.result.action_, out obj2))
                            {
                                this.result.hasAction = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x10:
                        {
                            object obj3;
                            if (input.ReadEnum<PegasusUtil.DBAction.Types.Result>(ref this.result.result_, out obj3))
                            {
                                this.result.hasResult = true;
                            }
                            else if (obj3 is int)
                            {
                            }
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasMetaData = input.ReadInt64(ref this.result.metaData_);
                }
                return this;
            }

            private DBAction PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DBAction result = this.result;
                    this.result = new DBAction();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DBAction.Builder SetAction(PegasusUtil.DBAction.Types.Action value)
            {
                this.PrepareBuilder();
                this.result.hasAction = true;
                this.result.action_ = value;
                return this;
            }

            public DBAction.Builder SetMetaData(long value)
            {
                this.PrepareBuilder();
                this.result.hasMetaData = true;
                this.result.metaData_ = value;
                return this;
            }

            public DBAction.Builder SetResult(PegasusUtil.DBAction.Types.Result value)
            {
                this.PrepareBuilder();
                this.result.hasResult = true;
                this.result.result_ = value;
                return this;
            }

            public PegasusUtil.DBAction.Types.Action Action
            {
                get
                {
                    return this.result.Action;
                }
                set
                {
                    this.SetAction(value);
                }
            }

            public override DBAction DefaultInstanceForType
            {
                get
                {
                    return DBAction.DefaultInstance;
                }
            }

            public bool HasAction
            {
                get
                {
                    return this.result.hasAction;
                }
            }

            public bool HasMetaData
            {
                get
                {
                    return this.result.hasMetaData;
                }
            }

            public bool HasResult
            {
                get
                {
                    return this.result.hasResult;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DBAction MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public long MetaData
            {
                get
                {
                    return this.result.MetaData;
                }
                set
                {
                    this.SetMetaData(value);
                }
            }

            public PegasusUtil.DBAction.Types.Result Result
            {
                get
                {
                    return this.result.Result;
                }
                set
                {
                    this.SetResult(value);
                }
            }

            protected override DBAction.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Action
            {
                A_UNKNOWN,
                A_GET_DECK,
                A_CREATE_DECK,
                A_RENAME_DECK,
                A_DELETE_DECK,
                A_SET_DECK,
                A_OPEN_BOOSTER,
                A_GAMES_INFO
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xd8
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Result
            {
                E_CONSTRAINT = 3,
                E_EXCEPTION = 9,
                E_NOT_FOUND = 4,
                E_NOT_OWNED = 2,
                E_SQL_EX = -1,
                E_SUCCESS = 1,
                E_UNKNOWN = 0
            }
        }
    }
}

