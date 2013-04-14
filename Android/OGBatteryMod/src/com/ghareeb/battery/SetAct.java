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

public class SetAct extends Activity implements OnClickListener {
	final SetAct me = this;
	Context ctx;
	Resources res;
	
	@Override
	public void onAttachedToWindow() {
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim1)
				.findViewById(R.id.img1)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim1)
				.findViewById(R.id.img2)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim1)
				.findViewById(R.id.img3)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim1)
				.findViewById(R.id.img4)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim1)
				.findViewById(R.id.img5)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim2)
				.findViewById(R.id.img1)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim2)
				.findViewById(R.id.img2)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim2)
				.findViewById(R.id.img3)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim2)
				.findViewById(R.id.img4)).getDrawable()).start();
		((AnimationDrawable) ((ImageView) me.findViewById(R.id.Anim2)
				.findViewById(R.id.img5)).getDrawable()).start();
	}
	
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.settings_layout);

		ctx = getBaseContext();
		res = getBaseContext().getResources();

		CheckBox cb = (CheckBox) this.findViewById(R.id.ChkAnim);
		setChargeImage1(
				(ImageView) me.findViewById(R.id.Anim1).findViewById(R.id.img1),
				0);
		setChargeImage1(
				(ImageView) me.findViewById(R.id.Anim1).findViewById(R.id.img2),
				25);
		setChargeImage1(
				(ImageView) me.findViewById(R.id.Anim1).findViewById(R.id.img3),
				50);
		setChargeImage1(
				(ImageView) me.findViewById(R.id.Anim1).findViewById(R.id.img4),
				75);
		setChargeImage1(
				(ImageView) me.findViewById(R.id.Anim1).findViewById(R.id.img5),
				100);

		setChargeImage2(
				(ImageView) me.findViewById(R.id.Anim2).findViewById(R.id.img1),
				0);
		setChargeImage2(
				(ImageView) me.findViewById(R.id.Anim2).findViewById(R.id.img2),
				25);
		setChargeImage2(
				(ImageView) me.findViewById(R.id.Anim2).findViewById(R.id.img3),
				50);
		setChargeImage2(
				(ImageView) me.findViewById(R.id.Anim2).findViewById(R.id.img4),
				75);
		setChargeImage2(
				(ImageView) me.findViewById(R.id.Anim2).findViewById(R.id.img5),
				100);

		((CompoundButton) this.findViewById(R.id.ChkPrc))
				.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
					@Override
					public void onCheckedChanged(CompoundButton buttonView,
							boolean isChecked) {
						if (isChecked) {
							SendVis(View.VISIBLE);
						} else {
							SendVis(View.GONE);
						}
					}
				});

		((CompoundButton) this.findViewById(R.id.Anim1).findViewById(
				R.id.CBox_Anim)).setClickable(false);
		((CompoundButton) this.findViewById(R.id.Anim2).findViewById(
				R.id.CBox_Anim)).setClickable(false);

		cb.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
			@Override
			public void onCheckedChanged(CompoundButton buttonView,
					boolean isChecked) {
				if (isChecked) {
					SendAnim(1);
					((CompoundButton) me.findViewById(R.id.Anim1).findViewById(
							R.id.CBox_Anim)).setChecked(true);
					((CompoundButton) me.findViewById(R.id.Anim2).findViewById(
							R.id.CBox_Anim)).setChecked(false);
					me.findViewById(R.id.Anims).setVisibility(View.VISIBLE);
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img1)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img2)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img3)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img4)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img5)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img1)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img2)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img3)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img4)).getDrawable())
							.start();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img5)).getDrawable())
							.start();

				} else {
					SendAnim(-1);
					me.findViewById(R.id.Anims).setVisibility(View.GONE);
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img1)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img2)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img3)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img4)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim1).findViewById(R.id.img5)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img1)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img2)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img3)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img4)).getDrawable())
							.stop();
					((AnimationDrawable) ((ImageView) me.findViewById(
							R.id.Anim2).findViewById(R.id.img5)).getDrawable())
							.stop();
				}
			}
		});

		this.findViewById(R.id.Anim1).setOnClickListener(this);
		this.findViewById(R.id.Anim2).setOnClickListener(this);

		if (getVis() == View.GONE) {
			((CompoundButton) this.findViewById(R.id.ChkPrc)).setChecked(false);
		}
		int Anim = getAnim();
		if (Anim == -1) {
			((CompoundButton) this.findViewById(R.id.ChkAnim))
					.setChecked(false);
		} else if (Anim == 1) {
			((CompoundButton) me.findViewById(R.id.Anim1).findViewById(
					R.id.CBox_Anim)).setChecked(true);
		} else if (Anim == 2) {
			((CompoundButton) me.findViewById(R.id.Anim2).findViewById(
					R.id.CBox_Anim)).setChecked(true);
		}
	}

	public void onClick(View arg0) {
		try {
			switch (arg0.getId()) {
			case R.id.Anim1:
				SendAnim(1);
				((CompoundButton) this.findViewById(R.id.Anim1).findViewById(
						R.id.CBox_Anim)).setChecked(true);
				((CompoundButton) this.findViewById(R.id.Anim2).findViewById(
						R.id.CBox_Anim)).setChecked(false);
				break;
			case R.id.Anim2:
				SendAnim(2);
				((CompoundButton) this.findViewById(R.id.Anim1).findViewById(
						R.id.CBox_Anim)).setChecked(false);
				((CompoundButton) this.findViewById(R.id.Anim2).findViewById(
						R.id.CBox_Anim)).setChecked(true);
				break;
			}
		} catch (Exception ex) {

		}

	}

	public void SendVis(int val) {
		Intent in = new Intent("com.ghareeb.OGMod.DATA_CHANGED");
		in.putExtra("Visibility", val);
		getBaseContext().sendBroadcast(in);
	}

	public void SendAnim(int val) {
		Intent in = new Intent("com.ghareeb.OGMod.DATA_CHANGED");
		in.putExtra("Anim", val);
		getBaseContext().sendBroadcast(in);
	}

	public int getImgID(String name) {
		return res.getIdentifier(name, "drawable", ctx.getPackageName());
	}

	public int getAnim() {
		int val = 1;
		try {
			Context ctx = getBaseContext().createPackageContext(
					"com.android.systemui",
					Context.CONTEXT_INCLUDE_CODE
							| Context.CONTEXT_IGNORE_SECURITY);
			SharedPreferences sp = ctx.getSharedPreferences("OG_Mod",
					Context.MODE_WORLD_READABLE);
			// TODO | Context.MODE_MULTI_PROCESS
			val = sp.getInt("Anim", 1);
		} catch (Exception e) {
			Log.d("OGMod", "getAnim() - Err:" + e.toString());
			e.printStackTrace();
		}
		return val;
	}

	public int getVis() {
		int val = View.GONE;
		try {
			Context ctx = getBaseContext().createPackageContext(
					"com.android.systemui",
					Context.CONTEXT_INCLUDE_CODE
							| Context.CONTEXT_IGNORE_SECURITY);
			SharedPreferences sp = ctx.getSharedPreferences("OG_Mod",
					Context.MODE_WORLD_READABLE);
			// TODO | Context.MODE_MULTI_PROCESS
			val = sp.getInt("Visibility", View.GONE);
		} catch (Exception e) {
			Log.d("OGMod", "getVis() - Err:" + e.toString());
			e.printStackTrace();
		}
		return val;
	}

	private void setChargeImage1(ImageView view, int value) {
		Drawable d1 = res.getDrawable(getImgID("stat_sys_battery_circle_"
				+ value));
		AnimationDrawable Animation = new AnimationDrawable();
		Animation.setOneShot(false);
		Animation.addFrame(d1, 2000);
		int duration = 40;
		for (int i = 0; i <= 100; i++) {
			try {
				Drawable d2 = res
						.getDrawable(getImgID("stat_sys_battery_circle_charge_anim"
								+ i));
				Animation.addFrame(d2, duration);
			} catch (Exception e) {
				duration = 80;
			}
		}
		view.setImageDrawable(Animation);
		((AnimationDrawable) view.getDrawable()).start();
	}

	private void setChargeImage2(ImageView view, int value) {
		Drawable d1 = res.getDrawable(getImgID("stat_sys_battery_circle_"
				+ value));
		Drawable d2 = res
				.getDrawable(getImgID("stat_sys_battery_circle_charge_anim"
						+ value));
		AnimationDrawable Animation = new AnimationDrawable();
		Animation.addFrame(d1, 1000);
		Animation.addFrame(d2, 1000);
		Animation.setOneShot(false);
		view.setImageDrawable(Animation);
		((AnimationDrawable) view.getDrawable()).start();
	}

}