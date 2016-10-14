package be.pxl.spring.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.User;

@Repository
public interface UserRepository extends CrudRepository<User, Integer>{
	
	@Transactional(readOnly = true)
	@Query("select u from User u where (u.firstName like %?1%) or (u.lastName like %?1%)")
	List<User> findByName(String name);

	@Transactional(readOnly=true)
	List<User> findByDepartment(String department);
}
