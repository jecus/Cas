﻿using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CAS.Entity.Core.ExecutorServices.Arcitecture
{
	public class SerializedSqlParam
	{
		[Browsable(false)]
		public string CompareInfo { get; set; }

		[RefreshProperties(RefreshProperties.All)]
		public string Direction { get; set; }

		public bool IsNullable { get; set; }

		[Browsable(false)]
		public int LocaleId { get; set; }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public int Offset { get; set; }


		public string ParameterName { get; set; }

		[DefaultValue(0)]
		public byte Precision { get; set; }

		[DefaultValue(0)]
		public byte Scale { get; set; }

		public int Size { get; set; }

		public string SourceColumn { get; set; }

		public bool SourceColumnNullMapping { get; set; }

		public string SourceVersion { get; set; }

		public string SqlDbType { get; set; }

		public string TypeName { get; set; }

		public string UdtTypeName { get; set; }

		public string Value { get; set; }

		public string ValueType { get; set; }

		public string XmlSchemaCollectionDatabase { get; set; }

		public string XmlSchemaCollectionName { get; set; }

		public string XmlSchemaCollectionOwningSchema { get; set; }

		public SerializedSqlParam()
		{
			
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
	}
}