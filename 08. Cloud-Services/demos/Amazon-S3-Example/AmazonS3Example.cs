using System;
using System.IO;

using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

class AmazonS3Example
{
	private const int BUFFER_SIZE = 1024 * 1024;

	static void Main()
	{
		// Connect to Amazon S3 service with authentication
		BasicAWSCredentials basicCredentials =
			new BasicAWSCredentials("AKIAIIYG27E27PLQ6EWQ", 
			"hr9+5JrS95zA5U9C6OmNji+ZOTR+w3vIXbWr3/td");
		AmazonS3Client s3Client = new AmazonS3Client(basicCredentials);

		// Display all S3 buckets
		ListBucketsResponse buckets = s3Client.ListBuckets();
		foreach (var bucket in buckets.Buckets)
		{
			Console.WriteLine(bucket.BucketName);
		}

		// Display and download the files in the first S3 bucket
		string bucketName = buckets.Buckets[0].BucketName;
		Console.WriteLine("Objects in bucket '{0}':", bucketName);
		ListObjectsResponse objects =
			s3Client.ListObjects(new ListObjectsRequest() { BucketName = bucketName });
		foreach (var s3Object in objects.S3Objects)
		{
			Console.WriteLine("\t{0} ({1})", s3Object.Key, s3Object.Size);
			if (s3Object.Size > 0)
			{
				// We have a file (not a directory) --> download it
				GetObjectResponse objData = s3Client.GetObject(
					new GetObjectRequest() { BucketName = bucketName, Key = s3Object.Key });
				string s3FileName = new FileInfo(s3Object.Key).Name;
				SaveStreamToFile(objData.ResponseStream, s3FileName);
			}
		}

		// Create a new directory and upload a file in it
		string path = "uploads/new_folder_" + DateTime.Now.Ticks;
		string newFileName = "example.txt";
		string fullFileName = path + "/" + newFileName;
		string fileContents = "This is an example file created through the Amazon S3 API.";
		s3Client.PutObject(new PutObjectRequest() { 
			BucketName = bucketName, 
			Key = fullFileName,
			ContentBody = fileContents}
		);
		Console.WriteLine("Created a file in Amazon S3: {0}", fullFileName);

		// Share the uploaded file and get a download URL
		string uploadedFileUrl = s3Client.GetPreSignedURL(new GetPreSignedUrlRequest()
		{ 
			BucketName = bucketName,
			Key = fullFileName,
			Expires = DateTime.Now.AddYears(5)
		});
		Console.WriteLine("File download URL: {0}", uploadedFileUrl);
		System.Diagnostics.Process.Start(uploadedFileUrl);
	}

	private static void SaveStreamToFile(Stream inputStream, string fileName)
	{
		using (FileStream outputFile = new FileStream(fileName, FileMode.Create))
		{
			byte[] buf = new byte[BUFFER_SIZE];
			while (true)
			{
				int bytesRead = inputStream.Read(buf, 0, buf.Length);
				if (bytesRead == 0)
				{
					break;
				}
				outputFile.Write(buf, 0, bytesRead);
			}
		}
	}
}
