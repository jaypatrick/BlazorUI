﻿namespace StoicDreams.BlazorUI;

public sealed class JsInterop : IJsInterop, IAsyncDisposable
{
	public const string InteropFilePath = "./sd-blazorui-interop.1.0.6.js";
	public JsInterop(IJSRuntime jsRuntime)
	{
		InteropModule = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", InteropFilePath).AsTask());
	}

	public async ValueTask CallMethod(string method, params object[] args)
	{
		IJSObjectReference module = await InteropModule.Value;
		try
		{
			await module.InvokeVoidAsync("CallMethod", method, args);
		}
		catch (Exception ex)
		{
			await module.InvokeVoidAsync("CallMethod", "console.error", method, $"JsInterop exception: {ex.Message}", args);
		}
	}

	public async ValueTask<TResult?> CallMethod<TResult>(string method, params object[] args)
	{
		IJSObjectReference module = await InteropModule.Value;
		try
		{
			return await module.InvokeAsync<TResult>("CallMethod", method, args);
		}
		catch (Exception ex)
		{
			await module.InvokeVoidAsync("CallMethod", "console.error", method, $"JsInterop exception: {ex.Message}", args);
			return default;
		}
	}

	public async ValueTask RunInlineScript(string script)
	{
		IJSObjectReference module = await InteropModule.Value;
		try
		{
			await module.InvokeVoidAsync("RunInlineScript", script);
		}
		catch (Exception ex)
		{
			await module.InvokeVoidAsync("CallMethod", "console.error", script, $"JsInterop exception: {ex.Message}");
		}
	}

	public async ValueTask<TResult?> RunInlineScript<TResult>(string script)
	{
		IJSObjectReference module = await InteropModule.Value;
		try
		{
			return await module.InvokeAsync<TResult>("RunInlineScript", script);
		}
		catch (Exception ex)
		{
			await module.InvokeVoidAsync("CallMethod", "console.error", script, $"JsInterop exception: {ex.Message}");
			return default;
		}
	}

	public async ValueTask AddJSFile(string filePath)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("AddJSFile", filePath);
	}

	public async ValueTask RemoveJSFile(string filePath)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("RemoveJSFile", filePath);
	}

	public async ValueTask RemoveSelector(string selector)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("RemoveSelector", selector);
	}

	public async ValueTask AddCSSFile(string filePath)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("AddCSSFile", filePath);
	}

	public async ValueTask AddElementToHead(string tag, IDictionary<string, string> attributes)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("AddElementToHead", tag, attributes);
	}

	public async ValueTask AddElementToBody(string tag, IDictionary<string, string> attributes)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("AddElementToBody", tag, attributes);
	}
	public async ValueTask UpdateTitle(string title)
	{
		IJSObjectReference module = await InteropModule.Value;
		await module.InvokeVoidAsync("UpdateTitle", title);
	}

	private Lazy<Task<IJSObjectReference>> InteropModule { get; }

	public async ValueTask DisposeAsync()
	{
		if (InteropModule.IsValueCreated)
		{
			IJSObjectReference module = await InteropModule.Value;
			await module.DisposeAsync();
		}
	}
}
