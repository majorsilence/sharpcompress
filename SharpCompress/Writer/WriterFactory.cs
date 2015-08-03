using System;
using System.IO;
using SharpCompress.Common;
using SharpCompress.Writer.GZip;
using SharpCompress.Writer.Tar;
using SharpCompress.Writer.Zip;
using SharpCompress.Writer.SevenZip;

namespace SharpCompress.Writer
{
    public static class WriterFactory
    {
        public static IWriter Open(Stream stream, ArchiveType archiveType, CompressionType compressionType)
        {
            return Open(stream, archiveType, new CompressionInfo
                                                 {
                                                     Type = compressionType
                                                 });
        }

        public static IWriter Open(Stream stream, ArchiveType archiveType, CompressionInfo compressionInfo)
        {
            switch (archiveType)
            {
                case ArchiveType.GZip:
                    {
                        if (compressionInfo.Type != CompressionType.GZip)
                        {
                            throw new InvalidFormatException("GZip archives only support GZip compression type.");
                        }
                        return new GZipWriter(stream);
                    }
                case ArchiveType.Zip:
                    {
                        return new ZipWriter(stream, compressionInfo, null);
                    }
                case ArchiveType.Tar:
                    {
                        return new TarWriter(stream, compressionInfo);
                    } 
                case ArchiveType.SevenZip:
                    {         
                        return new SevenZipWriter(stream);
                    }
                default:
                    {
                        throw new NotSupportedException("Archive Type does not have a Writer: " + archiveType);
                    }
            }
        }
    }
}