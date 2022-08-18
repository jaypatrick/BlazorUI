﻿namespace StoicDreams.BlazorUI.Data;

public class CardDetail : ICardDetail
{
	/// <summary>
	/// Path to image, svg html, or font-awesome icon class
	/// </summary>
	public string Avatar { get; set; } = string.Empty;

	/// <summary>
	/// Alt text to display when user mouses over Avatar or image is not loadable.
	/// </summary>
	public string AvatarAltText { get; set; } = string.Empty;

	/// <summary>
	/// Avatar color
	/// </summary>
	public Color AvatarColor { get; set; } = Color.Inherit;

	/// <summary>
	/// Content to render in card header (top third)
	/// </summary>
	public RenderFragment? Header { get; set; }

	/// <summary>
	/// Set color for header background
	/// </summary>
	public Color HeaderTheme { get; set; } = Color.Primary;

	/// <summary>
	/// Set with action to use for header action button.
	/// Header action button will not display if null.
	/// </summary>
	public EventCallback HeaderAction { get; set; }

	/// <summary>
	/// Set icon to use for header action button.
	/// Will not display if HeaderAction is not set.
	/// </summary>
	public string HeaderIcon { get; set; } = Icons.Material.TwoTone.Menu;

	/// <summary>
	/// Main content to render in card body (mid third)
	/// </summary>
	public RenderFragment? Content { get; set; }

	/// <summary>
	/// Content to render in card actions section (bottom third)
	/// </summary>
	public RenderFragment? Actions { get; set; }
}
