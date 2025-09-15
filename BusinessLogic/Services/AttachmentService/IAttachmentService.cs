using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services.AttachmentService
{
    //Types of Attachment Services
    //========================================//
    //File System Storage(Local Disk)

    //How it works: Files are uploaded and stored in the wwwroot/uploads/ folder(or another directory on the server).
    //Metadata(filename, path, size, content type) is stored in the database.

    //Pros:
    //Simple to implement.
    //Fast read/write on local disk.

    //Cons:
    //Limited by server storage.
    //Hard to scale across multiple servers.

    //When to use: Small/medium apps, local deployments.
    //========================================//
    //Database Storage(Binary / BLOBs)

    //How it works: File contents are stored directly inside the database as VARBINARY(MAX) (SQL Server) or BLOB(MySQL/Postgres).

    //Pros:
    //Strong consistency(data + file always in one place).
    //Backup & restore is easy(just DB backup).

    //Cons:
    //Can make DB very large.
    //Slower performance for large files.

    //When to use: Systems requiring strict transactional consistency (e.g., financial, medical records).
    //========================================//
    // Hybrid(File Path + Database Metadata)

    //How it works: File saved on disk, but only path and metadata stored in DB.

    //Pros:
    //Best of both worlds.
    //Database stays lean.

    //Cons:
    //Risk of mismatch (file deleted but DB record remains, or vice versa).

    //When to use: Common for business apps, like HR, ERP, or document management.
    //========================================//
    //Cloud Storage

    //Examples:
    //Azure Blob Storage
    //Amazon S3
    //Google Cloud Storage

    //How it works: Files are uploaded to cloud storage services via SDK or APIs.DB stores reference(URL or blob key).

    //Pros:
    //Highly scalable.
    //Secure and redundant.
    //Global access (CDN support).

    //Cons:
    //Costs money depending on storage/traffic.
    //Requires cloud configuration.

    //When to use: Enterprise apps, SaaS, applications with large files or many users.
    //========================================//
    //In-Memory / Temporary Storage

    //How it works: Files are stored in memory temporarily (e.g., for processing or previews), not persisted.

    //Pros:
    //Very fast access.

    //Cons:
    //Not durable, lost after restart.
    //Limited by server memory.

    //When to use: Caching, previews, temporary uploads before confirmation.
    public interface IAttachmentService
    {
        string? Upload(IFormFile file, string folderName);
        bool Delete(string filePath);
    }
}
