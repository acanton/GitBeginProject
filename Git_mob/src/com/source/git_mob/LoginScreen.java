package com.example.git_mob;


import android.app.Fragment;
import android.app.FragmentManager;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;


public class LoginScreen extends Fragment implements OnClickListener{

	View rootView;
	
	public LoginScreen() {
		
		
	}
	
	
	 @Override
	 public View onCreateView(LayoutInflater inflater, ViewGroup container,
	 		 Bundle savedInstanceState) {	  
	 	 rootView = inflater.inflate(R.layout.login_main, container, false);
	 	 
	 	 Button login    = (Button) rootView.findViewById(R.id.button_login);
	 	 Button register = (Button) rootView.findViewById(R.id.button_register);
	 	
	     login.setOnClickListener(this);    
	     register.setOnClickListener(this);
	     return rootView;
	 }


	
	public void onClick(View v) {
		Fragment fragment = null;
		EditText username = (EditText) rootView.findViewById(R.id.userid);
	 	EditText password = (EditText) rootView.findViewById(R.id.passid);
		
		switch (v.getId()) {
		
        case R.id.button_login:
        	
        	if("admin".equals(username.getText().toString()) &&"password".equals(password.getText().toString())){
        		 Toast.makeText(getActivity(),"I am on home screen", Toast.LENGTH_LONG).show();
        		fragment = new HomeFragment();
        		
        	}else {
        		Toast.makeText(getActivity(), "Incorrect UserName or Password! Please Check it", Toast.LENGTH_LONG).show();
        		
        	}	
        	break;
        case R.id.button_register:
        	break;
		
		}
		if (fragment != null) {
			
            FragmentManager fragmentManager = getFragmentManager();
            // transaction of fragment actually starts here
            fragmentManager.beginTransaction()
                    .replace(R.id.content_frame, fragment).commit();
 
           
            
        } else {
            // error in creating fragment
            Log.e("MainActivity", "Error in creating fragment");
        }

	}
	
}
