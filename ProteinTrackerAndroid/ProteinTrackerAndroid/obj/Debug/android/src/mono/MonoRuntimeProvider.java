package mono;

public class MonoRuntimeProvider
	extends android.content.ContentProvider
{
	public MonoRuntimeProvider ()
	{
	}

	@Override
	public boolean onCreate ()
	{
		return true;
	}

	@Override
	public void attachInfo (android.content.Context context, android.content.pm.ProviderInfo info)
	{
		// Mono Runtime Initialization {{{
		try {
			android.content.pm.ApplicationInfo runtimeInfo = context.getPackageManager ().getApplicationInfo ("Mono.Android.DebugRuntime", 0);
			android.content.pm.ApplicationInfo apiInfo = mono.MonoPackageManager.getApiPackageName () != null
				? context.getPackageManager ().getApplicationInfo (mono.MonoPackageManager.getApiPackageName (), 0)
				: null;
			mono.MonoPackageManager.LoadApplication (context, runtimeInfo.dataDir,
					apiInfo != null
					? new String[]{runtimeInfo.sourceDir, apiInfo.sourceDir, context.getApplicationInfo ().sourceDir}
					: new String[]{runtimeInfo.sourceDir, context.getApplicationInfo ().sourceDir});
		} catch (android.content.pm.PackageManager.NameNotFoundException e) {
			throw new RuntimeException ("Unable to find application Mono.Android.DebugRuntime" + 
					(mono.MonoPackageManager.getApiPackageName () == null ? "" : " or " + mono.MonoPackageManager.getApiPackageName ()) +
					"!", e);
		}
		// }}}
		super.attachInfo (context, info);
	}

	@Override
	public android.database.Cursor query (android.net.Uri uri, String[] projection, String selection, String[] selectionArgs, String sortOrder)
	{
		throw new RuntimeException ("This operation is not supported.");
	}

	@Override
	public String getType (android.net.Uri uri)
	{
		throw new RuntimeException ("This operation is not supported.");
	}

	@Override
	public android.net.Uri insert (android.net.Uri uri, android.content.ContentValues initialValues)
	{
		throw new RuntimeException ("This operation is not supported.");
	}

	@Override
	public int delete (android.net.Uri uri, String where, String[] whereArgs)
	{
		throw new RuntimeException ("This operation is not supported.");
	}

	@Override
	public int update (android.net.Uri uri, android.content.ContentValues values, String where, String[] whereArgs)
	{
		throw new RuntimeException ("This operation is not supported.");
	}
}

