using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SmartCore.Contract
{
	[DataContract]
	public class SerializedSqlParam
	{
		[Browsable(false)]
		[DataMember]
		public string CompareInfo { get; set; }

		[RefreshProperties(RefreshProperties.All)]
		[DataMember]
		public string Direction { get; set; }

		[DataMember]
		public bool IsNullable { get; set; }

		[Browsable(false)]
		[DataMember]
		public int LocaleId { get; set; }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DataMember]
		public int Offset { get; set; }

		[DataMember]
		public string ParameterName { get; set; }

		[DefaultValue(0)]
		[DataMember]
		public byte Precision { get; set; }

		[DefaultValue(0)]
		[DataMember]
		public byte Scale { get; set; }

		[DataMember]
		public int Size { get; set; }

		[DataMember]
		public string SourceColumn { get; set; }

		[DataMember]
		public bool SourceColumnNullMapping { get; set; }

		[DataMember]
		public string SourceVersion { get; set; }

		[DataMember]
		public string SqlDbType { get; set; }

		[DataMember]
		public string TypeName { get; set; }

		[DataMember]
		public string UdtTypeName { get; set; }

		[DataMember]
		public string Value { get; set; }

		[DataMember]
		public string ValueType { get; protected set; }

		[DataMember]
		public string XmlSchemaCollectionDatabase { get; set; }
		[DataMember]
		public string XmlSchemaCollectionName { get; set; }
		[DataMember]
		public string XmlSchemaCollectionOwningSchema { get; set; }

		public SerializedSqlParam(SqlParameter p)
		{
			this.CopyProperties(p);
			this.SerializeParameterValue(p);
		}

		public static explicit operator SerializedSqlParam(SqlParameter p)
		{
			return new SerializedSqlParam(p);
		}

		public static explicit operator SqlParameter(SerializedSqlParam p)
		{
			return p.GetSqlParameter(p);
		}

		public SqlParameter GetSqlParameter()
		{
			return this.GetSqlParameter(this);
		}

		public SqlParameter GetSqlParameter(SerializedSqlParam serialized)
		{
			SqlParameter p = new SqlParameter();

			p.ParameterName = serialized.ParameterName;
			p.Precision = serialized.Precision;
			p.Scale = serialized.Scale;
			p.Size = serialized.Size;
			p.IsNullable = serialized.IsNullable;
			p.LocaleId = serialized.LocaleId;
			p.Offset = serialized.Offset;
			p.SourceColumn = serialized.SourceColumn;
			p.SourceColumnNullMapping = serialized.SourceColumnNullMapping;

			p.XmlSchemaCollectionDatabase = serialized.XmlSchemaCollectionDatabase;
			p.XmlSchemaCollectionName = serialized.XmlSchemaCollectionName;
			p.XmlSchemaCollectionOwningSchema = serialized.XmlSchemaCollectionOwningSchema;

			p.TypeName = serialized.TypeName;
			p.UdtTypeName = serialized.UdtTypeName;

			p.Direction = (ParameterDirection)Enum.Parse(typeof(ParameterDirection), serialized.Direction);
			p.CompareInfo = (SqlCompareOptions)Enum.Parse(typeof(SqlCompareOptions), serialized.CompareInfo);
			p.SourceVersion = (DataRowVersion)Enum.Parse(typeof(DataRowVersion), serialized.SourceVersion);

			p.Value = this.DeserializeObject(serialized.Value, Type.GetType(serialized.ValueType));

			return p;
		}

		private void SerializeParameterValue(SqlParameter p)
		{
			if (p.Value.GetType().IsSerializable)
			{
				this.ValueType = this.GetTypeAssemblyQualifiedName(p.Value);
				this.Value = this.SerializeObject(p.Value);
			}
			else
			{
				throw new SerializationException("Cannot serialize the parameter value object. Recast that object into a primitive or class that can be serialized.");
			}
		}

		private void CopyProperties(SqlParameter p)
		{
			this.ParameterName = p.ParameterName;
			this.Precision = p.Precision;
			this.Scale = p.Scale;
			this.Size = p.Size;
			this.IsNullable = p.IsNullable;
			this.LocaleId = p.LocaleId;
			this.Offset = p.Offset;
			this.SourceColumn = p.SourceColumn;
			this.SourceColumnNullMapping = p.SourceColumnNullMapping;

			this.XmlSchemaCollectionDatabase = p.XmlSchemaCollectionDatabase;
			this.XmlSchemaCollectionName = p.XmlSchemaCollectionName;
			this.XmlSchemaCollectionOwningSchema = p.XmlSchemaCollectionOwningSchema;

			this.TypeName = p.TypeName;
			this.UdtTypeName = p.UdtTypeName;

			this.Direction = p.Direction.ToString();
			this.CompareInfo = p.CompareInfo.ToString();
			this.SourceVersion = p.SourceVersion.ToString();

			try
			{
				this.SqlDbType = p.SqlDbType.ToString();
			}
			catch
			{
				this.SqlDbType = null;
			}
		}

		private string SerializeObject(object value)
		{
			if (value == null) return null;

			XmlSerializer serializer = new XmlSerializer(value.GetType());
			XmlWriterSettings settings = new XmlWriterSettings();

			settings.Encoding = new UnicodeEncoding(false, false);
			settings.Indent = false;
			settings.OmitXmlDeclaration = false;

			using (StringWriter textWriter = new StringWriter())
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
				{
					serializer.Serialize(xmlWriter, value);
				}
				return textWriter.ToString();
			}
		}

		private object DeserializeObject(string xml, Type type)
		{
			if (string.IsNullOrEmpty(xml)) return null;

			XmlSerializer serializer = new XmlSerializer(type);

			XmlReaderSettings settings = new XmlReaderSettings();
			using (StringReader textReader = new StringReader(xml))
			{
				using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
				{
					return Convert.ChangeType(serializer.Deserialize(xmlReader), type);
				}
			}
		}

		private string GetTypeAssemblyQualifiedName(object obj)
		{
			return obj.GetType().AssemblyQualifiedName.ToString();
		}
	}
}