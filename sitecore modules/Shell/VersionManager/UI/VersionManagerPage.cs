//-------------------------------------------------------------------------------------------------
// <copyright file="VersionManagerPage.cs" company="Sitecore A/S">
// Copyright (C) 2010 by Sitecore A/S
// </copyright>
//-------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Web.UI;
using ComponentArt.Web.UI;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Grids;
using Sitecore.Web.UI.XamlSharp.Xaml;

#endregion

namespace Sitecore.VersionManager
{
    /// <summary>
    ///     Class that inits and fills the Version Manager UI
    /// </summary>
    public class VersionManagerPage : Page, IHasCommandContext
    {
        /// <summary>
        ///     Defines UI grid
        /// </summary>
        protected Grid itemsGrid;

        /// <summary>
        ///     Defines control with the caption "Version Manager is disabled"
        /// </summary>
        protected Control Disabled;

        /// <summary>
        ///     Defines GridContainer control in the xaml page.
        /// </summary>
        protected Control GridContainer;

        /// <summary>
        ///     Gets a CommandContext
        /// </summary>
        /// <returns>a CommandContext</returns>
        CommandContext IHasCommandContext.GetCommandContext()
        {
            string str;
            str = "/sitecore/content/Applications/Versions/Version Manager/Ribbon";
            Item itemNotNull = Client.GetItemNotNull(str, Client.CoreDatabase);
            CommandContext context = new CommandContext();
            context.RibbonSourceUri = itemNotNull.Uri;
            context.Parameters["item"] = GridUtil.GetSelectedValue("itemsGrid");
            return context;
        }

        protected override void OnLoad(EventArgs e)
        {
            Assert.ArgumentNotNull(e, "e");
            base.OnLoad(e);
            if (!VersionManager.IsDisabled)
            {
                GridContainer.Visible = true;
                Disabled.Visible = false;
                Sitecore.Context.ClientPage.Controls.Remove(Disabled);
                Assert.CanRunApplication("Versions/Version Manager");
                List<GridItem> itemEntry = new List<GridItem>();
                itemEntry = VersionManager.GetGridItem();
                Assert.IsNotNull(itemEntry, "itemEntry");
                ComponentArtGridHandler<GridItem>.Manage(itemsGrid, new GridSource<GridItem>(itemEntry), !XamlControl.AjaxScriptManager.IsEvent);
            }
            else
            {
                GridContainer.Visible = false;
                Disabled.Visible = true;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            Assert.ArgumentNotNull(e, "e");
            base.OnInit(e);
        }
    }
}