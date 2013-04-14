package com.ghareeb.battery;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager.NameNotFoundException;
import android.content.res.Resources;
import android.graphics.drawable.AnimationDrawable;
import android.graphics.drawable.Drawable;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.TextView;

public class BatteryListAdapter extends ArrayAdapter<String> implements
		OnClickListener {
	String[] objects;
	Context ctx;
	Resources res;
	String SelectedItem;
	ListView list;

	public BatteryListAdapter(Context context, int textViewResourceId,
			String[] objects, ListView list) {
		super(context, textViewResourceId, objects);
		ctx = getContext();
		res = ctx.getResources();

		this.objects = objects;
		SelectedItem = loadData();
		this.list = list;
	}

	public int getResID(String name, String Type) {
		return res
				.getIdentifier(name, Type, this.getContext().getPackageName());
	}

	public int getImgID(String name) {
		return res.getIdentifier(name, "drawable", ctx.getPackageName());
	}

	@SuppressLint("DefaultLocale")
	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
		View row = inflater.inflate(getResID("battery_style_item", "layout"),
				parent, false);
		row.setId(position);
		row.setOnClickListener(this);
		TextView tv = (TextView) row.findViewById(getResID("OG_Battery_Name",
				"id"));
		RadioButton tb = (RadioButton) row.findViewById(getResID(
				"OG_Battery_CBox", "id"));
		if (objects[position].equals(SelectedItem)) {
			tv.setTextColor(0xffff0000);
			tb.setChecked(true);
		}
		tv.setText(objects[position]);
		tb.setClickable(false);
		String name = "stat_sys_battery_"
				+ ((String) objects[position]).toLowerCase().replace(" ", "_")
				+ "_";

		ImageView view;
		int[] ids = new int[] { 0, 25, 50, 75, 100 };
		if (name.equals("stat_sys_battery_default_")) {
			ids = new int[] { 0, 28, 57, 71, 100 };
		}

		view = (ImageView) row.findViewById(getResID("OG_Battery_Icon1", "id"));
		setImage(view, name, ids[0]);

		view = (ImageView) row.findViewById(getResID("OG_Battery_Icon2", "id"));
		setImageCharge(view, name, ids[1]);

		view = (ImageView) row.findViewById(getResID("OG_Battery_Icon3", "id"));
		setImage(view, name, ids[2]);

		view = (ImageView) row.findViewById(getResID("OG_Battery_Icon4", "id"));
		setImageCharge(view, name, ids[3]);

		view = (ImageView) row.findViewById(getResID("OG_Battery_Icon5", "id"));
		setImage(view, name, ids[4]);
		return row;
	}

	private void setImage(ImageView view, String name, int id) {
		try {
			Drawable d2 = res.getDrawable(getImgID(name + id));
			view.setImageDrawable(d2);
		} catch (Exception e) {
		}
	}

	private void setImageCharge(ImageView view, String name, int id) {
		try {
			Drawable d2 = res.getDrawable(getImgID(name + "charge_anim" + id));
			view.setImageDrawable(d2);
		} catch (Exception e) {
		}
	}

	public String loadData() {
		String val = "Default";
		try {
			Context ctx = getContext().createPackageContext(
					"com.android.systemui",
					Context.CONTEXT_INCLUDE_CODE
							| Context.CONTEXT_IGNORE_SECURITY);
			SharedPreferences sp = ctx.getSharedPreferences("OG_Mod",
					Context.MODE_WORLD_READABLE );
			//TODO | Context.MODE_MULTI_PROCESS
			val = sp.getString("BatteryStyle", "Default");
		} catch (Exception e) {
			Log.d("OGMod", "loadData() - Err:" + e.toString());
			e.printStackTrace();
		}
		return val;
	}

	@Override
	public void onClick(View v) {
		SelectedItem = objects[v.getId()].toString();
		list.setSelection(v.getId());
		TextView tv = (TextView) v.findViewById(getResID("OG_Battery_Name",
				"id"));
		RadioButton tb = (RadioButton) v.findViewById(getResID(
				"OG_Battery_CBox", "id"));
		tv.setTextColor(0xffff0000);
		tb.setChecked(true);
		this.notifyDataSetChanged();
		Intent in = new Intent("com.ghareeb.OGMod.DATA_CHANGED");
		in.putExtra("data", SelectedItem);
		getContext().sendBroadcast(in);
	}

}