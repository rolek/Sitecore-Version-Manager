//-------------------------------------------------------------------------------------------------
// <copyright file="GridItem.cs" company="Sitecore A/S">
// Copyright (C) 2010 by Sitecore A/S
// </copyright>
//-------------------------------------------------------------------------------------------------

#region Usings

using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

#endregion

namespace Sitecore.VersionManager
{
    /// <summary>
    ///     the source class for a grid
    /// </summary>
    public class GridItem
    {
        #region Fields

        /// <summary>
        ///     consist of item id and item language, separated by '^'
        /// </summary>
        private readonly string itemLang;

        /// <summary>
        ///     stores item name
        /// </summary>
        private readonly string name;

        /// <summary>
        ///     stores item language
        /// </summary>
        private readonly string language;

        /// <summary>
        ///     stores nubmer of versions in one item language
        /// </summary>
        private readonly int versionCount;

        /// <summary>
        ///     stores item path
        /// </summary>
        private readonly string itemPath;

        /// <summary>
        ///     stores item id
        /// </summary>
        private readonly ID id;

        #endregion

        /// <summary>
        ///     Initializes a new instance of the GridItem class
        /// </summary>
        /// <param name="item">source item for initialization</param>
        public GridItem(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            itemLang = item.ID + "^" + item.Language;
            name = item.Name;
            language = item.Language.ToString();
            versionCount = item.Versions.Count;
            itemPath = item.Paths.FullPath;
            id = item.ID;
        }

        #region Properties

        /// <summary>
        ///     Gets itemLang value
        /// </summary>
        public string ItemLang
        {
            get { return itemLang; }
        }

        /// <summary>
        ///     Gets itemPath value
        /// </summary>
        public string ItemPath
        {
            get { return itemPath; }
        }

        /// <summary>
        ///     Gets versionCount value
        /// </summary>
        public int VersionCount
        {
            get { return versionCount; }
        }

        /// <summary>
        ///     Gets name value
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        ///     Gets language value
        /// </summary>
        public string Language
        {
            get { return language; }
        }

        /// <summary>
        ///     Gets id value
        /// </summary>
        public ID ID
        {
            get { return id; }
        }

        #endregion
    }
}