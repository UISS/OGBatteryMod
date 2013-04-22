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

public class StyAct extends Activity  {

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.style_layout);

		ListView list = (ListView) findViewById(R.id.StylesList);
		String[] Styles = getResources().getStringArray(R.array.BatteryStyles);
		BatteryListAdapter slist = new BatteryListAdapter(this, R.layout.battery_style_item,
				Styles,list);
		list.setAdapter(slist);
		
	}

}