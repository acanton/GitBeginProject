package com.example.git_mob;

import java.util.ArrayList;
import java.util.List;

import android.os.Bundle;
import android.app.Activity;
import android.app.Fragment;
import android.app.FragmentManager;
import android.content.Context;
import android.support.v4.widget.DrawerLayout;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity {

	private ArrayList<NavDrawerItem> mylist = new ArrayList<NavDrawerItem>();
	ListView list;
	Button login_button;
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		populatelist();
		populatelistView();
		registerClickCallback();
		
		if (savedInstanceState == null) {
            // on first time display view for first nav item
            displayView(1);
        }
		login_button = (Button) findViewById(R.id.button_login);
	
	}

	private void populatelist() {
		mylist.add(new NavDrawerItem("Home",R.drawable.home_icon));
		mylist.add(new NavDrawerItem("Login",R.drawable.login_icon));
		mylist.add(new NavDrawerItem("ListInfo",R.drawable.theme));
	}

	private void populatelistView() {

		NavDrawerListAdapter badapter = new NavDrawerListAdapter(getApplicationContext(),mylist);
		list = (ListView) findViewById(R.id.GitBeginListView);
	
		list.setAdapter(badapter);
		
	}
	
	private void displayView(int position){
		// fragment object is create here
		Fragment fragment = null;
		switch(position){
		case 0:
			
			fragment = new HomeFragment();
			
			break;
		case 1:
			fragment = new LoginScreen();
			
			break;
		case 2:
			fragment = new ListInfo();
		
		}
		
		if (fragment != null) {
			
            FragmentManager fragmentManager = getFragmentManager();
            // transaction of fragment actually starts here
            fragmentManager.beginTransaction()
                    .replace(R.id.content_frame, fragment).commit();
 
            // update selected item and title, then close the drawer
            list.setItemChecked(position, true);
            list.setSelection(position);
            
        } else {
            // error in creating fragment
            Log.e("MainActivity", "Error in creating fragment");
        }
	}
	
	private void registerClickCallback() {
		final ListView list = (ListView)findViewById(R.id.GitBeginListView);
		list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View viewClicked, int position,
					long id) {
				
				displayView(position);
			}

			
			
		});
		
	}
	
	private class NavDrawerListAdapter extends BaseAdapter{
		
		private Context context;
	    private ArrayList<NavDrawerItem> navDrawerItems;
		
	    public NavDrawerListAdapter(Context context, ArrayList<NavDrawerItem> navDrawerItems){
	        this.context = context;
	        this.navDrawerItems = navDrawerItems;
	    }

		@Override
		public int getCount() {
			return navDrawerItems.size();
		}

		@Override
		public Object getItem(int position) {
			return navDrawerItems.get(position);
		}

		@Override
		public long getItemId(int position) {
			return position;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent) {
			// we have to create if there was no view create before
			View itemView = convertView;
			if(itemView == null){
				itemView = getLayoutInflater().inflate(R.layout.each_list_view_formation, parent,false);
			}
			
			//find and populate the list
			NavDrawerItem current = navDrawerItems.get(position);
			
			// fill the view
			TextView textView = (TextView)itemView.findViewById(R.id.item_textView);
			textView.setText(current.getTitle());
			
			
			return itemView;
		}
		
	}
	
	
	

}

