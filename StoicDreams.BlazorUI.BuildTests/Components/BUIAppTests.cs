﻿namespace StoicDreams.BlazorUI.Components;

public class BUIAppTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIApp> actions = ArrangeRenderTest<BUIApp>(options =>
		{
			options.Parameters.Add("ChildContent", MockRender("Mock Content"));
		}, this.StartupTestServices);

		actions.Act(a =>
		{
			a.GetService<IAppState>().TriggerChange("PageTitle");
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("The page you are looking for could not be found");
		});

		actions.Act(a =>
		{
			a.DetachRender();
		});

		actions.Assert(a =>
		{
			a.Render.IsDisposed.Should().BeTrue();
		});
	}
}
