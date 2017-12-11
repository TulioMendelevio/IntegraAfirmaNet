using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Web.Services3.Design;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Web.Services3.Security.Tokens;

namespace IntegraAfirmaNet.SignatureFramework
{
    /// <summary>
    /// Clase de herramientas para el uso del SignatureFramework
    /// </summary>
    class Tools
    {
        /// <summary>
        /// Clase para crear un TokenProvider desde un almac�n de claves externo
        /// </summary>
        public class ExternalX509TokenProvider : X509TokenProvider
        {
            X509Certificate2 certificate = null;

            /// <summary>
            /// Crea un TokenProvider a partir de un fichero de claves y su password
            /// </summary>
            /// <param name="keystorePath">Ruta del almac�n de claves</param>
            /// <param name="keystorePassword">Password que protege el almac�n</param>
            public ExternalX509TokenProvider(String keystorePath, String keystorePassword)
            {
                certificate = new X509Certificate2(keystorePath, keystorePassword);
            }

            /// <summary>
            /// Proporciona el X509SecurityToken asociado al almacen identificado.
            /// </summary>
            /// <returns>null si ha ocurrido alg�n error en el acceso al almac�n</returns>
            public override X509SecurityToken GetToken()
            {
                return new X509SecurityToken(certificate);
            }
        }

    }
}
