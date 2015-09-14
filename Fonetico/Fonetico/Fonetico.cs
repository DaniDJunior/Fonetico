using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;

namespace Fonetico
{
    public class Fonetico
    {

        public static string CAMINHOFONETICO
        {
            get
            {
                return ConfigurationManager.AppSettings["CaminhoFonetico"].ToString();
            }
        }

        /// <summary>
        /// Remove os caracteres especias de uma string
        /// </summary>
        /// <param name="str">String a ter os dados substituidos</param>
        /// <param name="chrSubistituido">Caracter que irá no lugar dos caracteres especiais</param>
        /// <returns>String sem caracteres especiais</returns>
        public static string RemoverCaracterEspeciais(string str, char chrSubistituido)
        {
            string strTemp = str;
            string strEspeciais = @"""!#$%-*+'_/:;<=>?@[\],^_`{|}~´()ªº§.";
            foreach (char i in strEspeciais.ToCharArray())
            {
                strTemp = strTemp.Replace(i, chrSubistituido);
            }
            return strTemp;
        }

        /// <summary>
        /// Remove os acentos e ç de uma string
        /// </summary>
        /// <param name="str">String a ter os dados substituidos</param>
        /// <returns>String sem aacentos</returns>
        public static string RemoverAcentos(string str)
        {
            string strTemp = str.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < strTemp.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(strTemp[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strTemp[k]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converte apenas uma palavra no seu equivalente fonético
        /// </summary>
        /// <param name="strPalavar">Palavra a ser convertida</param>
        /// <returns>Palavra convertida para o fonético</returns>
        private static string RetornaPalavraFonetico(string strPalavar)
        {
            if (strPalavar != string.Empty)
            {
                StringBuilder strTemp = new StringBuilder(string.Empty);
                strTemp.Append(strPalavar);
                //Troca ÃO por AM no final do nome
                if (strTemp.ToString().EndsWith("AO"))
                    strTemp.Replace('O', 'M', strTemp.Length - 1, 1);

                //Troca BAPTI para BATI no início do nome
                strTemp.Replace("BAPTI", "BATI");

                //Troca OPTI para OTI
                strTemp.Replace("OPTI", "OTI");

                //Palavras terminadas em RD, remover a letra D.
                if ((strTemp.Length > 3) && (strTemp.ToString().EndsWith("RD")))
                    strTemp.Remove(strTemp.Length - 1, 1);

                //Substitui GEO, JEO, GIO, JIO, GYO e JYO por JO
                strTemp.Replace("GEO", "JO");
                strTemp.Replace("JEO", "JO");
                strTemp.Replace("GIO", "JO");
                strTemp.Replace("JIO", "JO");
                strTemp.Replace("GYO", "JO");
                strTemp.Replace("JYO", "JO");

                //Considera "EIA" = "EA" (Exemplo: Andreia = Andrea)
                strTemp.Replace("EIA", "EA");

                //Aplica as regras fonéticas do H. Quando não possui regra, elimina o H
                for (int z = 0; z < strTemp.Length; z++)
                {
                    bool blnRemoveH = true;
                    if ((strTemp[z] == 'H') && (strTemp.Length > 1))
                    {
                        if (z > 0)
                        {
                            switch (strTemp[z - 1])
                            {
                                case 'C':
                                    {
                                        if (z == strTemp.Length - 1)
                                        {
                                            strTemp.Replace('H', 'K', z, 1);
                                            strTemp.Append('E');
                                            blnRemoveH = false;
                                        }
                                        else
                                        {
                                            if ("AEIOUY".IndexOf(strTemp[z + 1]) > -1)
                                                strTemp.Replace('C', 'X', z - 1, 1);
                                        }
                                        break;
                                    }
                                case 'S':
                                    {
                                        strTemp.Replace('S', 'X', z - 1, 1);
                                        break;
                                    }
                                case 'L':
                                    {
                                        strTemp.Replace('H', 'I', z, 1);
                                        blnRemoveH = false;
                                        break;
                                    }
                                case 'P':
                                    {
                                        strTemp.Replace('P', 'F', z - 1, 1);
                                        break;
                                    }
                            }
                        }

                        if (blnRemoveH) strTemp.Remove(z, 1);
                    }
                }

                //Palavras terminadas em consoantes
                string strUltimaLetra = strTemp[strTemp.Length - 1].ToString();
                if ("BCDFGJKPQTV".IndexOf(strUltimaLetra) > -1)
                    strTemp.Insert(strTemp.Length, 'E');

                //Regra fonética para S no início do nome
                //Caso a próxima letra seja uma consoante, acrescente a letra E antes do S. Ex.: Stenio = Estenio
                if ((strTemp[0] == 'S') && (strTemp.Length > 2))
                    if ("AEIOUY".IndexOf(strTemp[1].ToString(), 0, 6) == -1)
                        strTemp.Insert(0, 'I');

                //Elimina letras duplicadas
                char chrLetra;
                for (int z = 0; z < strTemp.Length - 1; z++)
                {
                    chrLetra = strTemp[z];
                    if (chrLetra == strTemp[z + 1])
                    {
                        if ((chrLetra != '0') && (chrLetra != '1') && (chrLetra != '2') && (chrLetra != '3') && (chrLetra != '4') && (chrLetra != '5') && (chrLetra != '6') && (chrLetra != '7') && (chrLetra != '8') && (chrLetra != '9'))
                        {
                            strTemp.Remove(z, 1);
                            z -= 1;
                        }
                    }
                }

                //Aplica as regras foneticas para C, G, L, P, Q, S, N, W e Z
                for (int z = 0; z < strTemp.Length; z++)
                {
                    switch (strTemp[z])
                    {
                        /*****Regra fonética para C*****
                         * Para a letra C existem três regras definidas. 
                         * 1 - Quando a próxima letra for E, I ou Y o C tem som de S - Ex.: Celio = Selio , Cicero = Sisero
                         * 2 - Quando a proxima letra for K ou T o som do C é despresado. Ex.: Packal = Pakal, Pictolomeu = Pitolomeu)
                         * 3 - Quando a próxima letra for S o som do C tem semelhança ao X. Ex.: Alecsandro = Alexsandro
                         * */
                        case 'C':
                            if (z < strTemp.Length - 1)
                            {
                                if ("EIY".IndexOf(strTemp[z + 1]) > -1)
                                    strTemp.Replace('C', 'S', z, 1);
                                else if ("TK".IndexOf(strTemp[z + 1]) > -1)
                                    strTemp.Remove(z, 1);
                                else if (strTemp[z + 1].ToString() == "S")
                                    strTemp.Replace('C', 'X', z, 1);
                            }
                            continue;

                        //Regra fonética para G
                        case 'G':
                            if (z < strTemp.Length - 1)
                            {
                                if ("EIY".IndexOf(strTemp[z + 1]) > -1)
                                {
                                    strTemp.Replace('G', 'J', z, 1);
                                }
                                else if (strTemp[z + 1] == 'U')
                                {
                                    if (strTemp.Length > z + 2)
                                    {
                                        if ("AEIOUY".IndexOf(strTemp[z + 2]) > -1)
                                        {
                                            strTemp.Remove(z + 1, 1);
                                        }
                                    }
                                    else
                                    {
                                        strTemp.Remove(z + 1, 1);
                                    }
                                }
                                else if (strTemp[z + 1] == 'N')
                                {
                                    strTemp.Remove(z, 1); //Exemplo: Ignacio = Inacio
                                }
                            }
                            continue;

                        //*****Regra fonética para L*****
                        case 'L':
                            /*O L como primeira letra da palavra não demanda substituição fonética
                            Apenas para os casos em que o L está no meio ou no final da palavra
                            ele poderá exercer um outro valor fonético como 'U' */
                            if (z > 0)
                            {
                                if (z == strTemp.Length - 1) //L é a última letra
                                {
                                    if ("AEIOUY".IndexOf(strTemp[z - 1]) > -1) //Letra anterior é uma vogal
                                        strTemp.Replace('L', 'U', z, 1);
                                }
                                else //L está no meio da palavra
                                {
                                    if ("AEIOUY".IndexOf(strTemp[z - 1]) > -1) //Letra anterior é uma vogal
                                        if ("AEIOUY".IndexOf(strTemp[z + 1]) == -1) //Letra posterios é uma consoante
                                            strTemp.Replace('L', 'U', z, 1);
                                }
                            }
                            continue;

                        //Regra fonética para P
                        case 'P':
                            if (z < strTemp.Length - 1)
                            {
                                if (strTemp[z + 1] == 'C')
                                    strTemp.Replace('C', 'I', z + 1, 1);
                            }
                            continue;

                        /*****Regra fonética para Q******
                         * Para a letra Q será considerado apenas quando a próxima letra for U, eliminando-a.
                         * Todas as letras Q's tem o mesmo valor fonético de C e K
                         * */
                        case 'Q':
                            if (z < strTemp.Length - 1)
                                if (strTemp[z + 1] == 'U')
                                    if (strTemp.Length > z + 2)
                                        if ("EIY".IndexOf(strTemp[z + 2]) > -1)
                                        {
                                            strTemp.Remove(z + 1, 1);
                                            z -= 1;
                                        }

                            continue;

                        /********Regra fonética para S*****
                        No Caso da letra S, serão considerados os casos SC e SW.
                        No primeiro o C será eliminado, figurando apenas o som do S. Ex. Escenios = Esenios
                        No segundo caso o W passa a ter som de U. Ex.: Swing = Suing
                        Para o cálculo fonético, o C e o K possuem o mesmo valor*/
                        case 'S':
                            if (z < strTemp.Length - 1)
                            {
                                if (strTemp[z + 1] == 'C')
                                {
                                    if (strTemp.Length > z + 2)
                                    {
                                        if ("EI".IndexOf(strTemp[z + 2]) > -1)
                                        {
                                            strTemp.Remove(z + 1, 1);
                                            z -= 1;
                                        }
                                    }
                                }
                            }
                            else if ((strTemp.Length > 3) && (z == strTemp.Length - 1))
                                strTemp.Remove(z, 1);

                            continue;

                        /*****Regra fonética para N*****
                         * Para a letra N, o valor fonético será de M, a menos que a próxima letra seja uma vogal
                         * */
                        case 'N':
                            if (z < strTemp.Length - 1)
                            {
                                if ("AEIOUY".IndexOf(strTemp[z + 1]) == -1)
                                    strTemp.Replace('N', 'M', z, 1);
                            }
                            else
                                strTemp.Replace('N', 'M', z, 1);

                            continue;

                        /*****Regra fonética para W*****
                         *A letra W possui som de V quando existe uma vogal em seguida e som de U nos outros casos
                         **/
                        case 'W':
                            if (z < strTemp.Length - 1)
                            {
                                if ("AEIOUY".IndexOf(strTemp[z + 1]) == -1)
                                    strTemp.Replace('W', 'U', z, 1);
                            }
                            continue;

                        case 'Z':
                            if ((strTemp.Length > 3) && (z == strTemp.Length - 1))
                                strTemp.Remove(z, 1);

                            continue;

                        default:
                            continue;
                    }
                }

                /*****Regras de fonética para encontro de consoantes*****
                 * Para o encontro de consoantes, será considerado o som da consoante, acrescentando a letra
                 * I no meio. Ex.: Pta = Pita. Bta = Bita. Como a letra E e I tem o mesmo valor fonético, 
                 * consoantes com som de E no final também terão o mesmo valor
                 * */
                for (int z = 0; z < strTemp.Length - 1; z++)
                {
                    if ("0123456789".IndexOf(strTemp[z]) == -1)
                        if ("AEIOUYRLMNSX0".IndexOf(strTemp[z]) == -1)
                            if ("LRAEIOUY".IndexOf(strTemp[z + 1]) == -1)
                                strTemp.Insert(z + 1, 'I');
                }

                //Considera "OU" = "U" (Exemplo: Lourdes = Lurdes)
                strTemp.Replace("OU", "U");

                return strTemp.ToString();

            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Converte um texto para seu equivalente fonético
        /// </summary>
        /// <param name="strNome">Texto a ser convertido</param>
        /// <returns>Texto convertido para o fonético</returns>
        public static string RetornaFonetico(string strNome)
        {

            DICIONARIO dicTermos = DICIONARIO.Open(CAMINHOFONETICO);

            //Remove Espaços Duplicados e Tranforma tudo para Maiusculo.
            string strTrabalho = strNome.Trim().ToUpper();

            //Remove Caractes especiais
            strTrabalho = RemoverCaracterEspeciais(strTrabalho, ' ');

            //Adiciona espaço no final e no começo para identificar na Subistituição
            strTrabalho = " " + strTrabalho + " ";

            //Lista de StopWords
            List<string> lstStopWords = dicTermos.STOPWORD;

            //Subistitui as StopWords
            foreach (string i in lstStopWords)
            {
                strTrabalho = strTrabalho.Replace(" " + i + " ", " ");
            }

            //Dicionario de Sinonimos Compostos
            Dictionary<string, string> dcnSinonimosCompostos = SIGNIFICADO.CONVERTE(dicTermos.SIGNIFICADOCOMPOSTO);

            //Subistirui Sinonimos Compostos
            foreach (KeyValuePair<string, string> i in dcnSinonimosCompostos)
            {
                strTrabalho = strTrabalho.Replace(" " + i.Key + " ", " " + i.Value + " ");
            }

            //Dicionario de Sinonimos Simples
            Dictionary<string, string> dcnSinonimos = SIGNIFICADO.CONVERTE(dicTermos.SIGNIFICADOS);

            //Subistirui Sinonimos Simples
            foreach (KeyValuePair<string, string> i in dcnSinonimos)
            {
                strTrabalho = strTrabalho.Replace(" " + i.Key + " ", " " + i.Value + " ");
            }

            //Retira Acentuo
            strTrabalho = RemoverAcentos(strTrabalho);

            //Substitui Y por I
            strTrabalho.Replace('Y', 'I');

            //Efetua o algorítimo fonético para cada nome do nome completo
            string strRetorno = string.Empty;

            foreach (string i in strTrabalho.Trim().Split(' '))
            {
                strRetorno += RetornaPalavraFonetico(i) + " ";
            }

            return strRetorno.Trim();
        }

        /// <summary>
        /// Gera o código fonético de um texto
        /// </summary>
        /// <param name="strNome">Texto a ser convertido em código fonético</param>
        /// <returns>Código fonético de retorno</returns>
        public static string RetornaCodigoFonetico(string strNome)
        {
            string[] arrFonemas = new string[26] {/*a*/"0", /*b*/"1", /*c*/"2", /*d*/"3", /*e*/"4", /*f*/"5", 
													 /*g*/"D", /*h*/"0", /*i*/"4", /*j*/"6", /*k*/"2", /*l*/"7",
													 /*m*/"8", /*n*/"9", /*o*/"A", /*p*/"1", /*q*/"2", /*r*/"B",
													 /*s*/"C", /*t*/"3", /*u*/"A", /*v*/"5", /*w*/"5", /*x*/"C",
													 /*y*/"4", /*z*/"C"};

            string strNomeFonetico = RetornaFonetico(strNome);

            StringBuilder stbCodigoFonetico = new StringBuilder("");

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] bytCodASC = ascii.GetBytes(strNomeFonetico);

            for (int i = 0; i < strNomeFonetico.Length; i++)
            {
                if (strNomeFonetico[i] == ' ')
                    stbCodigoFonetico.Append(' ');
                else if ((bytCodASC[i] > 64) && (bytCodASC[i] < 91))
                    stbCodigoFonetico.Append(arrFonemas[bytCodASC[i] - 65]);
                else
                    stbCodigoFonetico.Append(strNomeFonetico[i]);
            }

            string[] arrCodigosFoneticos = stbCodigoFonetico.ToString().Split(" ".ToCharArray());
            string strCodigoFonetico = "";
            string strAuxiliar = stbCodigoFonetico.ToString();
            int intContador;

            for (intContador = 0; intContador <= arrCodigosFoneticos.Length - 1; intContador++)
            {
                strCodigoFonetico += arrCodigosFoneticos[intContador] + " ";
            }
            return strCodigoFonetico.Trim();
        }

    }

    public class DICIONARIO
    {
        public List<string> STOPWORD { get; set; }
        public List<SIGNIFICADO> SIGNIFICADOCOMPOSTO { get; set; }
        public List<SIGNIFICADO> SIGNIFICADOS { get; set; }

        public DICIONARIO()
        {
            STOPWORD = new List<string>();
            SIGNIFICADOCOMPOSTO = new List<SIGNIFICADO>();
            SIGNIFICADOS = new List<SIGNIFICADO>();
        }

        public static void Salvar(string Caminho, DICIONARIO arquivo)
        {
            StreamWriter Arquivo = new StreamWriter(Caminho);
            XmlSerializer serializer = new XmlSerializer(typeof(DICIONARIO));
            serializer.Serialize(Arquivo, arquivo);
            Arquivo.Close();
        }

        public static DICIONARIO Open(string Caminho)
        {
            DICIONARIO aux = new DICIONARIO();
            StreamReader Arquivo = new StreamReader(Caminho);
            XmlSerializer serializer = new XmlSerializer(typeof(DICIONARIO));
            aux = (DICIONARIO)serializer.Deserialize(Arquivo);
            Arquivo.Close();
            return aux;
        }

    }

    public class SIGNIFICADO
    {
        public string CHAVE { get; set; }
        public string VALOR { get; set; }

        public SIGNIFICADO()
        {
            CHAVE = string.Empty;
            VALOR = string.Empty;
        }

        public SIGNIFICADO(string chave, string valor)
        {
            CHAVE = chave;
            VALOR = valor;
        }

        public static Dictionary<string, string> CONVERTE(List<SIGNIFICADO> lista)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            foreach (SIGNIFICADO i in lista)
            {
                temp.Add(i.CHAVE, i.VALOR);
            }
            return temp;
        }
    }
}
