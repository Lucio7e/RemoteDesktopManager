using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsumeWebServiceRest;

namespace RDMService
{
    public class ServiceRDM : IServiceRDM
    {
        // PLAGE DES CODES ERREUR POUR LE WebService ---> [1 - 200[
        public const int CodeRet_Ok = 0;
        public const int CodeRet_PseudoUtilise = 1;
        public const int CodeRet_PseudoObligatoire = 2;
        public const int CodeRet_PseudoDownloadObligatoire = 3;
        public const int CodeRet_Logout = 4;
        public const int CodeRet_PasswordObligatoire = 5;
        public const int CodeRet_PasswordIncorrect = 6;
        public const int CodeRet_PseudoDownloadLogout = 7;
        public const int CodeRet_ParamKeyInconnu = 10;
        public const int CodeRet_ParamTypeInvalid = 11;
        public const int CodeRet_ErreurInterneService = 100;

        #region IserviceRDM Membres
        /// <summary>
        /// Permet de se loguer au WebService
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant</param>
        /// <returns>Valeurs de retour contenant votre mot de passe. Il sera nécessaire pour le Logout et l'écriture de vos données</returns>

        public WSR_Result Login(WSR_Params p)
        {
            string pseudo = null;
            string password = null;
            WSR_Result ret = null;

            //On vérifie que le pseudo est bien passé en paramètres
            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
                return ret;

            //On ajoute le pseudo dans la liste des utilisateurs, on récupère un mot de passe et on renvoi un code erreur
            AccountError err = Account.Add(pseudo, out password);

            switch (err)
            {
                //tout se passe bien
                case AccountError.Ok:
                    ret = new WSR_Result();
                    break;
                //Le pseudo passé est vide/null
                case AccountError.KeyNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOVIDE);
                    break;
                //Le pseudo passé existe déjà
                case AccountError.KeyExist:
                    ret = new WSR_Result(CodeRet_PseudoUtilise, string.Format(Properties.Resources.KEYUTILISE,pseudo));                    
                    break;                
                default:
                    ret = new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNE);
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Permet de se Déloguer du WebService
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant et votre mot de passe></param>
        /// <returns>Valeurs de retour</returns>
        public WSR_Result Logout(WSR_Params p)
        {
            string pseudo = null;
            string password = null;
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
                return ret;

            //On verifie que le mot de passe est bien passé en paramètre
            ret = VerifParamType(p, "password", out password);
            if (ret != null)
                return ret;
            //On efface le compte utilisateur de la liste des utlisateurs connectés et on renvoi un code erreur
            AccountError err = Account.Remove(pseudo, password);
            switch (err)
            {
                case AccountError.Ok:
                    ret = new WSR_Result();
                    break;
                case AccountError.KeyNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOVIDE);
                    break;
                    //Mot de passe vide
                case AccountError.PasswordNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PasswordObligatoire, Properties.Resources.PWDVIDE);
                    break;
                    //Le compte utilisateur n'existe pas
                case AccountError.keyNotFound:
                    ret = new WSR_Result(CodeRet_ParamKeyInconnu,string.Format(Properties.Resources.PARAMKEYINCONNU,pseudo));
                    break; 
                    //Mot de passe erroné              
                case AccountError.PasswordWrong:
                    ret = new WSR_Result(CodeRet_PasswordIncorrect, Properties.Resources.PWDWRONG);
                    break;
                default:
                    ret = new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNE);
                    break;
            }
           
            return ret;
        }
        /// <summary>
        /// Permet d'obtenir la liste des utilisateurs logués au WebService
        /// </summary>
        /// <param name="p">Dictionnaire contenant votre identifiant et votre mot de passe</param>
        /// <returns>Valeurs de retour contenant la liste des utilisateurs connectés</returns>
        public WSR_Result GetPseudos(WSR_Params p)
        {
            string pseudo = null;
            string password = null;
            List<string> lstKeys = null;
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
                return ret;

            ret = VerifParamType(p, "password", out password);
            if (ret != null)
                return ret;

            AccountError err = Account.GetKeys(pseudo, password, out lstKeys);
            switch (err)
            {
                case AccountError.Ok:
                    //on renvoi la liste des utilisateurs, sérialisée
                    ret = new WSR_Result(lstKeys,true);
                    break;
                case AccountError.KeyNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOVIDE);
                    break;
                case AccountError.PasswordNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PasswordObligatoire, Properties.Resources.PWDVIDE);
                    break;
                case AccountError.keyNotFound:
                    ret = new WSR_Result(CodeRet_ParamKeyInconnu, string.Format(Properties.Resources.PARAMKEYINCONNU, pseudo));
                    break;
                case AccountError.PasswordWrong:
                    ret = new WSR_Result(CodeRet_PasswordIncorrect, Properties.Resources.PWDWRONG);
                    break;
                default:
                    ret = new WSR_Result(CodeRet_ErreurInterneService,Properties.Resources.ERREURINTERNE);
                    break;
            }
            return ret;
        }

        public WSR_Result UploadData(WSR_Params p)
        {
            string pseudo = null;
            string password = null;            
            object data = null;
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
                return ret;

            ret = VerifParamType(p, "password", out password);
            if (ret != null)
                return ret;

            ret = VerifParamExist(p, "data", out data);
            if (ret != null)
                return ret;

            AccountError err = Account.WriteData(pseudo, password, data);
            switch (err)
            {
                case AccountError.Ok:
                    ret = new WSR_Result();
                    break;
                case AccountError.KeyNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOVIDE);
                    break;
                case AccountError.PasswordNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PasswordObligatoire, Properties.Resources.PWDVIDE);
                    break;
                case AccountError.keyNotFound:
                    ret = new WSR_Result(CodeRet_ParamKeyInconnu, string.Format(Properties.Resources.PARAMKEYINCONNU, pseudo));
                    break;
                case AccountError.PasswordWrong:
                    ret = new WSR_Result(CodeRet_PasswordIncorrect, Properties.Resources.PWDWRONG);
                    break;
                default:
                    ret = new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNE);
                    break;
            }
            return ret;
        }
        public WSR_Result DownloadData(WSR_Params p)
        {

            string pseudo = null;
            string password = null;
            string pseudoDownload = null;
            object data = null;
            WSR_Result ret = null;

            ret = VerifParamType(p, "pseudo", out pseudo);
            if (ret != null)
                return ret;

            ret = VerifParamType(p, "password", out password);
            if (ret != null)
                return ret;

            ret = VerifParamType(p, "pseudoDownload", out pseudoDownload);
            if (ret != null)
                return ret;

            ret = VerifParamExist(p, "data", out data);
            if (ret != null)
                return ret;

            AccountError err = Account.ReadData(pseudo, password,pseudoDownload,out data);
            switch (err)
            {
                case AccountError.Ok:
                    ret = new WSR_Result(data,false);
                    break;
                case AccountError.KeyNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PseudoObligatoire, Properties.Resources.PSEUDOVIDE);
                    break;
                case AccountError.PasswordNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PasswordObligatoire, Properties.Resources.PWDVIDE);
                    break;
                case AccountError.keyDownloadNullOrEmpty:
                    ret = new WSR_Result(CodeRet_PseudoDownloadObligatoire, Properties.Resources.KEYDOWNLOADVIDE);
                    break;               
                case AccountError.PasswordWrong:
                    ret = new WSR_Result(CodeRet_PasswordIncorrect, Properties.Resources.PWDWRONG);
                    break;
                case AccountError.keyNotFound:
                    ret = new WSR_Result(CodeRet_ParamKeyInconnu, string.Format(Properties.Resources.PARAMKEYINCONNU, pseudo));
                    break;
                case AccountError.keyDownloadNotFound:
                    ret = new WSR_Result(CodeRet_PseudoDownloadLogout, string.Format(Properties.Resources.KEYDOWNLOADLOGOUT, pseudoDownload));
                    break;
                default:
                    ret = new WSR_Result(CodeRet_ErreurInterneService, Properties.Resources.ERREURINTERNE);
                    break;
            }
            return ret;
        }
        #endregion

        #region Fonctions perso

        /// <summary>
        /// Verifie dans le dictionnaire que le paramètre dont on donne la clé existe 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static WSR_Result VerifParamExist(WSR_Params p, string key, out object data)
        {
            data = null;

            if (!p.ContainsKey(key))
                return new WSR_Result(CodeRet_ParamKeyInconnu, String.Format(Properties.Resources.PARAMKEYINCONNU, key));

            data = p.GetValueSerialized(key);

            return null;
        }

        /// <summary>
        /// Verifie dans le dictionnaire le type du paramètre dont on donne la clé
        /// </summary>
        /// <typeparam name="T">Generic</typeparam>
        /// <param name="p">Le dictionnaire de parametre</param>
        /// <param name="key">La clé</param>
        /// <param name="value">Out le type du paramètre</param>
        /// <returns></returns>
        private static WSR_Result VerifParamType<T>(WSR_Params p, string key, out T value) where T : class
        {
            object data = null;
            value = null;

            WSR_Result ret = VerifParamExist(p, key, out data);
            if (ret != null)
                return ret;

            if (p[key] != null)
            {
                try
                {
                    value = p[key] as T; // Permet de vérifier le type
                }
                catch (Exception) { } // Il peut y avoir exception si le type est inconnu (type personnalisé qui n'est pas dans les références)

                if (value == null)
                    return new WSR_Result(CodeRet_ParamTypeInvalid, String.Format(Properties.Resources.PARAMTYPEINVALID, key));
            }

            return null;
        }

        #endregion Fonctions perso
    }
}
