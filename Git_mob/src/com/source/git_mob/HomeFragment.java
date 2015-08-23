package com.example.git_mob;


import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;


public class HomeFragment extends Fragment {

	public HomeFragment() {
		// TODO Auto-generated constructor stub
	}
	
	
	
	 @Override
	 public View onCreateView(LayoutInflater inflater, ViewGroup container,
			 Bundle savedInstanceState) {	  
		
		 View rootView = inflater.inflate(R.layout.home_main, container, false);
	          
	        return rootView;
	    }
	 
	 

}
