Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Net
Imports System.IO

Public Class FTP
  Private __host As String
  Private __user As String
  Private __pass As String
  Private __ftpRequest As FtpWebRequest
  Private __ftpResponse As FtpWebResponse
  Private __ftpStream As Stream
  Private __bufferSize As Integer = 2048

  Public Sub New(ByVal hostIP As String, ByVal userName As String, ByVal password As String)
    __host = hostIP
    __user = userName
    __pass = password
  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="targetRemoteFile"></param>
  ''' <param name="sourceRemoteFileData"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function __upload(ByVal targetRemoteFile As String, ByVal sourceRemoteFileData As Byte()) As Boolean
    Try
      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" & targetRemoteFile), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.Method = WebRequestMethods.Ftp.UploadFile
      Dim clsStream As System.IO.Stream = __ftpRequest.GetRequestStream()
      clsStream.Write(sourceRemoteFileData, 0, sourceRemoteFileData.Length)
      clsStream.Close()
      clsStream.Dispose()
      Return True

    Catch
      Return False

    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="sourceRemoteFile"></param>
  ''' <param name="targetRemoteFile"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function copiarArchivoDentroDeFTP(ByVal sourceRemoteFile As String, ByVal targetRemoteFile As String) As Boolean
    Try
      Dim ms As New MemoryStream()
      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" + sourceRemoteFile), FtpWebRequest)
      __ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      __ftpStream = __ftpResponse.GetResponseStream()
      __ftpStream.CopyTo(ms)
      __ftpResponse.Close()
      __ftpStream.Close()
      __ftpRequest = Nothing
      Return __upload(targetRemoteFile, ms.ToArray())

    Catch
      If __ftpStream IsNot Nothing Then
        __ftpStream.Close()
        __ftpStream.Dispose()
      End If
      Return False

    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="remoteFile"></param>
  ''' <param name="localFile"></param>
  ''' <remarks></remarks>
  Public Sub upload(ByVal remoteFile As String, ByVal localFile As Stream)
    Try
      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" + remoteFile), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.UploadFile
      __ftpStream = __ftpRequest.GetRequestStream()
      localFile.CopyTo(__ftpStream)
      localFile.Close()
      __ftpStream.Close()
      __ftpRequest = Nothing

    Catch ex As Exception
      If __ftpStream IsNot Nothing Then
        __ftpStream.Close()
        __ftpStream.Dispose()
      End If

    End Try
  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="filePath"></param>
  ''' <param name="directory"></param>
  ''' <remarks></remarks>
  Public Sub download(ByVal filePath As String, ByVal directory As String)
    Dim reqFTP As FtpWebRequest = Nothing
    Dim ftpStream As Stream = Nothing

    Try
      Dim outputStream As New FileStream(filePath, FileMode.Create)
      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" + directory), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      ftpStream = __ftpResponse.GetResponseStream()

      Dim cl As Long = __ftpResponse.ContentLength
      Dim bufferSize As Integer = 2048
      Dim readCount As Integer
      Dim buffer As Byte() = New Byte(bufferSize - 1) {}

      readCount = ftpStream.Read(buffer, 0, bufferSize)
      While readCount > 0
        outputStream.Write(buffer, 0, readCount)
        readCount = ftpStream.Read(buffer, 0, bufferSize)
      End While

      ftpStream.Close()
      outputStream.Close()
      __ftpResponse.Close()
    Catch ex As Exception
      If ftpStream IsNot Nothing Then
        ftpStream.Close()
        ftpStream.Dispose()
      End If
    End Try
  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="fileName"></param>
  ''' <remarks></remarks>
  Public Sub deleteFile(ByVal fileName As String)
    Try
      __ftpRequest = CType(WebRequest.Create(__host + "/" + fileName), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      __ftpResponse.Close()
      __ftpRequest = Nothing
    Catch ex As Exception
      Console.WriteLine(ex.ToString())
    End Try
  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="currentFileNameAndPath"></param>
  ''' <param name="newFileName"></param>
  ''' <remarks></remarks>
  Public Sub renameFile(ByVal currentFileNameAndPath As String, ByVal newFileName As String)
    Try
      __ftpRequest = CType(WebRequest.Create(__host + "/" + currentFileNameAndPath), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.Rename
      __ftpRequest.RenameTo = newFileName
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      __ftpResponse.Close()
      __ftpRequest = Nothing
    Catch ex As Exception
      Console.WriteLine(ex.ToString())
    End Try
  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="newDirectory"></param>
  ''' <remarks></remarks>
  Public Sub makeDirectory(ByVal newDirectory As String)
    Try
      __ftpRequest = CType(WebRequest.Create(__host + "/" + newDirectory), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      __ftpResponse.Close()
      __ftpRequest = Nothing
    Catch ex As Exception
      Console.WriteLine(ex.ToString())
    End Try
  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="fileName"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function getFileCreationDate(ByVal fileName As String) As String
    Try
      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" + fileName), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      __ftpStream = __ftpResponse.GetResponseStream()

      Dim ftpReader As New StreamReader(__ftpStream)
      Dim fileInfo As String = ""

      Try
        fileInfo = ftpReader.ReadToEnd()
      Catch ex As Exception
        Console.WriteLine(ex.ToString())
      End Try

      ftpReader.Close()
      __ftpStream.Close()
      __ftpStream.Dispose()
      __ftpResponse.Close()
      __ftpRequest = Nothing

      Return fileInfo
    Catch ex As Exception
      If __ftpStream IsNot Nothing Then
        __ftpStream.Close()
        __ftpStream.Dispose()
      End If
      Console.WriteLine(ex.ToString())

      Return ""
    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="fileName"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function getFileSize(ByVal fileName As String) As String
    Try
      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" + fileName), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      __ftpStream = __ftpResponse.GetResponseStream()

      Dim ftpReader As New StreamReader(__ftpStream)
      Dim fileInfo As String = ""

      Try
        While ftpReader.Peek() <> -1
          fileInfo = ftpReader.ReadToEnd()
        End While
      Catch ex As Exception
        Console.WriteLine(ex.ToString())
      End Try

      ftpReader.Close()
      __ftpStream.Close()
      __ftpStream.Dispose()
      __ftpResponse.Close()
      __ftpRequest = Nothing

      Return fileInfo
    Catch ex As Exception
      If __ftpStream IsNot Nothing Then
        __ftpStream.Close()
        __ftpStream.Dispose()
      End If
      Console.WriteLine(ex.ToString())

      Return ""
    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="fileName"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function getStream(ByVal fileName As String) As Byte()
    Dim reqFTP As FtpWebRequest = Nothing
    Dim ftpStream As Stream = Nothing

    Try
      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" + fileName), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      ftpStream = __ftpResponse.GetResponseStream()

      Dim bufferSize As Integer = 2048
      Dim readCount As Integer
      Dim buffer As Byte() = New Byte(bufferSize - 1) {}

      Dim msFoto As New MemoryStream()

      readCount = ftpStream.Read(buffer, 0, bufferSize)
      While readCount > 0
        msFoto.Write(buffer, 0, readCount)
        readCount = ftpStream.Read(buffer, 0, bufferSize)
      End While

      __ftpResponse.Close()
      ftpStream.Close()
      ftpStream.Dispose()

      Return msFoto.ToArray()
    Catch ex As Exception
      If ftpStream IsNot Nothing Then
        ftpStream.Close()
        ftpStream.Dispose()
      End If

      Return Nothing
    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="directory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function fileList(ByVal directory As String) As List(Of String)
    Try
      Dim directoryRaw As New List(Of String)

      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" + directory), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      __ftpStream = __ftpResponse.GetResponseStream()

      Dim ftpReader As New StreamReader(__ftpStream)

      While ftpReader.Peek() <> -1
        directoryRaw.Add(ftpReader.ReadLine())
      End While

      ftpReader.Close()
      __ftpStream.Close()
      __ftpStream.Dispose()
      __ftpResponse.Close()
      __ftpRequest = Nothing

      Return directoryRaw
    Catch ex As Exception
      If __ftpStream IsNot Nothing Then
        __ftpStream.Close()
        __ftpStream.Dispose()
      End If

      Return Nothing
    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="directory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function getFullFileList(ByVal directory As String) As String()
    Try
      __ftpRequest = CType(FtpWebRequest.Create(__host + "/" + directory), FtpWebRequest)
      __ftpRequest.Credentials = New NetworkCredential(__user, __pass)
      __ftpRequest.UseBinary = True
      __ftpRequest.UsePassive = True
      __ftpRequest.KeepAlive = True
      __ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails
      __ftpResponse = CType(__ftpRequest.GetResponse(), FtpWebResponse)
      __ftpStream = __ftpResponse.GetResponseStream()

      Dim ftpReader As New StreamReader(__ftpStream)
      Dim directoryRaw As String = ""

      Try
        While ftpReader.Peek() <> -1
          directoryRaw += ftpReader.ReadLine() + "|"
        End While
      Catch ex As Exception
        Console.WriteLine(ex.ToString())
      End Try

      ftpReader.Close()
      __ftpStream.Close()
      __ftpStream.Dispose()
      __ftpResponse.Close()
      __ftpRequest = Nothing

      Try
        Dim directoryList As String() = directoryRaw.Split("|".ToCharArray())
        Return directoryList
      Catch ex As Exception
        Console.WriteLine(ex.ToString())
      End Try
    Catch ex As Exception
      If __ftpStream IsNot Nothing Then
        __ftpStream.Close()
        __ftpStream.Dispose()
      End If
      Console.WriteLine(ex.ToString())
    End Try

    Return New String() {""}
  End Function

End Class
