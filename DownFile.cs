/*
 * fileName:parameter,
 * fileSize:parameter;
 * fileContent:parameter;
 * */
private void DownFile(string fileName,string fileSize,byte[] fileContent)
{
	Response.Buffer=true;
	HttpResponse contextResponse = HttpContext.Current.Response;
	contextResponse.Clear();
	contextResponse.Buffer = true;
	contextResponse.Charset = "Big5"; //set type as chinese to avoid appear garbled GB2312 Big5
	contextResponse.AppendHeader("Content-Disposition",String.Format("attachment;filename={0}",Server.UrlEncode(fileName)));  //Define output File and File Name
	contextResponse.AppendHeader("Content-Length",fileSize.ToString());
	contextResponse.ContentEncoding = Encoding.Default;
	if(fileName.Tolower().IndexOf(".pdf") > 0)
	{
		contextResponse.ContentType = "Application/pdf";
	}
	else
	{
		contextResponse.ContentType = "application/ms-excel";  //set output file type as excel
	}
	Response.BinaryWrite(fileContent);
	contextResponse.Flush();
	contextResponse.End();


}
