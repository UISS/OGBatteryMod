package com.ghareeb.battery;

import android.app.Activity;
import android.app.TabActivity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager.NameNotFoundException;
import android.content.res.Resources;
import android.graphics.drawable.AnimationDrawable;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TabHost;
import android.widget.TabHost.TabSpec;

public class Settings extends TabActivity {
	final Settings me = this;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.settings);

		TabHost tabHost = getTabHost();
		TabSpec SettingsSpec = tabHost.newTabSpec("Settings");
		SettingsSpec.setIndicator("Settings");
		SettingsSpec.setContent(new Intent(this, SetAct.class));
		
		TabSpec StylesSpec = tabHost.newTabSpec("Styles");
		StylesSpec.setIndicator("Styles");
		StylesSpec.setContent(new Intent(this, StyAct.class));
		
	    tabHost.addTab(SettingsSpec); 
        tabHost.addTab(StylesSpec);
	}


}