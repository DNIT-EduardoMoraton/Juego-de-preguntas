using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.services
{
    class BlobService
    {
        public static string getBlob(String path)
        {
            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=trivialedu;AccountKey=ZLNCSVkZB/C4pBLnbUODrNZwNQOfYMq6Jo7MGAgQm2eSunYX/3eFWLAkzMCPtZwvjIZFTyduzis0+AStiwWiQw==;EndpointSuffix=core.windows.net"; 
            string nombreContenedorBlobs = "trivial"; 
            

            
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

            
            Stream streamImagen = File.OpenRead(path);
            string nombreImagen = Path.GetFileName(path);
            clienteContenedor.UploadBlob(nombreImagen, streamImagen);

           
            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;


            return urlImagen;
        }
    }
}
