Function Download-File {
Param (
	[Parameter(Mandatory=$True)] [System.Uri]$uri,
	[Parameter(Mandatory=$True )] [string]$FilePath
)

    #Make sure the destination directory exists
    #System.IO.FileInfo works even if the file/dir doesn't exist, which is better then get-item which requires the file to exist
    If (! ( Test-Path ([System.IO.FileInfo]$FilePath).DirectoryName ) ) { [void](New-Item ([System.IO.FileInfo]$FilePath).DirectoryName -force -type directory)}

    #see if this file exists
    if ( -not (Test-Path $FilePath) ) {
        #use simple download
        $webClient = New-Object System.Net.WebClient
        $webClient.Headers.Add("User-Agent: PennysFlyingCircus")
        [void] $webClient.DownloadFile($uri.ToString(), $FilePath)
        Extract-File $FilePath
    } else {
        try {
            #use HttpWebRequest to download file
            $webRequest = [System.Net.HttpWebRequest]::Create($uri);
            $webRequest.IfModifiedSince = ([System.IO.FileInfo]$FilePath).LastWriteTime
            $webRequest.UserAgent = "PennysFlyingCircus"
            $webRequest.Method = "GET";
            [System.Net.HttpWebResponse]$webResponse = $webRequest.GetResponse()

            #Read HTTP result
            $stream = New-Object System.IO.StreamReader($response.GetResponseStream())
            #Save to file
            $stream.ReadToEnd() | Set-Content -Path $FilePath -Force 
            Extract-File $FilePath
        } catch [System.Net.WebException] {
            #Check for a 304
            if ($_.Exception.Response.StatusCode -eq [System.Net.HttpStatusCode]::NotModified) {
                Write-Host "  $FilePath not modified, not downloading..."
            } else {
                #Unexpected error
                $Status = $_.Exception.Response.StatusCode
                $msg = $_.Exception
                Write-Host "  Error dowloading $FilePath, Status code: $Status - $msg"
            }
        }
    }
}

Function Extract-File {
Param(
    [Parameter(Mandatory=$True)] [string]$archiveFile
)

    $outputDir = Split-Path $archiveFile -Parent

    .\7za x -y -o"$outputDir" $archiveFile
}

Download-File https://www.fuzzwork.co.uk/dump/sqlite-latest.sqlite.bz2 ..\..\EveMarket.Web\App_Data\sqlite-latest.sqlite.bz2
